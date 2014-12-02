using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServer.API.JSON
{
    class JSONObject
    {
        protected object _content;

        public virtual object GetContent()
        {
            return this._content;
        }
    }
}
