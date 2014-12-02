using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServer.API.Authorization
{
    class PermitsTools
    {

        public enum Permits : int { USER_READ_PUBLIC_INFORMATIONS  = 0x00000001,
                                    USER_READ_PRIVATE_INFORMATIONS = 0x00000002
                                    };

        public static List<Permits> GetPermits(int permits)
        {
            List<Permits> permitsList = new List<Permits>();
            var values = Enum.GetValues(typeof(Permits));

            int i = 0;
            foreach (int permit in values)
            {

                if ((permits & permit) == permit)
                {
                    Permits tmp = (Permits)Enum.ToObject(typeof(Permits), permit);
                    permitsList.Add(tmp);
                }

                i++;
            }

            return permitsList;
        }
    }
}
