using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandcess
{
    internal class AccessController
    {
        public static bool SetPermission(string path, uint permission)
        {
            permission |= 0xc0000003;
            string reqData = (
                "SetPermission " +
                path + " " +
                Convert.ToChar((ushort)(permission >> 16)) +
                Convert.ToChar((ushort)(permission & 0xffff))
            );
            return (AgentController.SendDataToDriver(reqData) == "0");
        }
    }
}
