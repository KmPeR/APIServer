using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServer.API.JSON
{
    class JSONString : JSONObject
    {
        public JSONString(string content)
        {
            this._content = content;
        }

        public override object GetContent()
        {
            return (object)("\"" + this._content + "\"");
        }
    }
}
