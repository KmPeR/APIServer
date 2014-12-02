using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using APIServer.API.Subroutines;
using APIServer.API.JSON;
using APIServer.API.Authorization;

namespace APIServer
{
    class Program
    {

        private HttpListener _httpListener;

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            this._httpListener = new HttpListener();
            this._httpListener.Prefixes.Add("http://localhost:8080/");

            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());

            this.Start();
        }

        public void Start()
        {

            this._httpListener.Start();

            HttpListenerContext _httpContext;
            HttpListenerRequest _httpRequest;
            HttpListenerResponse _httpResponse;
            while (true)
            {
                _httpContext = this._httpListener.GetContext();
                _httpRequest = _httpContext.Request;
                _httpResponse = _httpContext.Response;

                List<string> _Path = new List<string>(_httpRequest.Url.AbsolutePath.Split('/'));
                _Path.RemoveAll(s => string.IsNullOrEmpty(s));

                NameValueCollection headers =  _httpRequest.Headers;
                foreach (string key in headers.AllKeys)
                {
                    string[] values = headers.GetValues(key);
                    if (values.Length > 0)
                    {
                        foreach (string value in values)
                        {
                            Console.WriteLine("{0}: {1}", key, value);
                        }
                    }
                }

                foreach (string type in _httpRequest.AcceptTypes)
                {
                    Console.WriteLine(type);
                }

                if (_Path.Count == 0)
                {
                    this.sendSimpleResponseAsText(_httpContext, 400, "", "Zla sciezka!!!");
                }
                else
                {
                    ISubroutine subroutine = null;
                    switch (_Path[0].ToLower())
                    {
                        case "users":
                            _Path.Reverse(1, _Path.Count - 1);
                            subroutine = new Users(_Path.ToArray());
                            break;
                    }

                    if (subroutine != null)
                    {
                        byte[] data = ASCIIEncoding.UTF8.GetBytes((string)subroutine.GetData().GetContent());

                        Console.WriteLine((string)subroutine.GetData().GetContent());

                        _httpResponse.StatusCode = 201;
                        _httpResponse.StatusDescription = "Accepted";

                        _httpResponse.ContentType = "application/json";
                        _httpResponse.ContentLength64 = data.Length;

                        using (Stream sOut = _httpResponse.OutputStream)
                        {
                            sOut.Write(data, 0, data.Length);
                        }
                    }
                }
            }

        }

        public string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed && !string.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }

        private void sendSimpleResponseAsText(HttpListenerContext httpContext, int httpStatusCode, string httpStatusDescription, string data)
        {
            HttpListenerResponse httpResponse = httpContext.Response;
            byte[] buff = ASCIIEncoding.UTF8.GetBytes(data);

            httpResponse.StatusCode = httpStatusCode;
            httpResponse.StatusDescription = httpStatusDescription;

            httpResponse.ContentType = "application/text";
            httpResponse.ContentLength64 = buff.Length;
            httpResponse.ProtocolVersion = HttpVersion.Version11;


            using(Stream outStream = httpResponse.OutputStream)
            {
                outStream.Write(buff, 0, buff.Length);
            }
        }

        private void requestGET(HttpListenerRequest request)
        {

        }

        private void requestPOST(HttpListenerRequest request)
        {

        }

        private void requestPUT(HttpListenerRequest request)
        {

        }

        private void requestDELETE(HttpListenerRequest request)
        {

        }
    }
}
