using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using APIServer.API.JSON;

namespace APIServer.API.Subroutines
{
    class Users : ISubroutine
    {

        private string[] _args;

        public Users(string[] args)
        {
            this._args = args;
        }

        public JSONObject GetData()
        {
            JSONContainer jsonContainer = new JSONContainer();
            JSONContainer jsonUserContainer = new JSONContainer();
            JSONContainer userLinks = new JSONContainer();

            userLinks.AddChildren("self", "/users/kmper");
            userLinks.AddChildren("friends", "/users/kmper/friends");
            userLinks.AddChildren("images", "/users/kmper/images");

            jsonUserContainer.AddChildren("username", "kmper");
            jsonUserContainer.AddChildren("_links", userLinks);

            jsonContainer.AddChildren("status", "OK");
            jsonContainer.AddChildren("user", jsonUserContainer);

            return jsonContainer;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
