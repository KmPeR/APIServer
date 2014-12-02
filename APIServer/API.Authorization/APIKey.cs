using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APIServer.API.Authorization;

namespace APIServer.API.Authorization
{
    class APIKey
    {
        private string _key;
        private List<PermitsTools.Permits> _permits;

        public APIKey(string key, int permits)
        {
            this._key = key;
            this._permits = PermitsTools.GetPermits(permits);

            Console.WriteLine(this._permits.Count);
        }
    }
}
