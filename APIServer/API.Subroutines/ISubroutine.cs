using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using APIServer.API.JSON;

namespace APIServer.API.Subroutines
{
    interface ISubroutine
    {
        void Execute();

        JSONObject GetData();
    }
}
