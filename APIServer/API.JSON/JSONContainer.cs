using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServer.API.JSON
{
    class JSONContainer : JSONObject
    {
        public Dictionary<JSONString, JSONObject> _childrens;

        public JSONContainer()
        {
            this._childrens = new Dictionary<JSONString, JSONObject>();
        }

        public void AddChildren(JSONString key, JSONObject content)
        {
            this._childrens.Add(key, content);
        }

        public void AddChildren(string key, JSONObject content)
        {
            this._childrens.Add(new JSONString(key), content);
        }

        public void AddChildren(string key, string content)
        {
            this._childrens.Add(new JSONString(key), new JSONString(content));
        }

        public void AddChildren(string key, int content)
        {
            this._childrens.Add(new JSONString(key), new JSONInteger(content));
        }

        public override object GetContent()
        {
            //TODO: wciecia, nowe linie itp.
            
            StringBuilder jsonContent = new StringBuilder();
            int i = 0;

            jsonContent.Append("{");
            foreach(KeyValuePair<JSONString, JSONObject> con in this._childrens)
            {
                jsonContent.Append((string)con.Key.GetContent() + ":" + (string)con.Value.GetContent());
                if (i != this._childrens.Count - 1) jsonContent.Append(",");

                i++;
            }
            jsonContent.Append("}");

            return jsonContent.ToString();
        }
    }
}
