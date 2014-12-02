using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServer.API.JSON
{
    class JSONInteger : JSONObject
    {
        public JSONInteger(int content)
        {
            this._content = content;
        }
    }
}
