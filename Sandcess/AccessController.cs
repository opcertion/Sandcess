using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandcess
{
    internal class AccessController
    {
        enum ACCESS_TYPE
        {
            __RESERVED1 = 0,
            __RESERVED2,
            /* File System */
            READ_FILE,
            WRITE_FILE,
            MOVE_FILE,
            /* Process */
            CREATE_PROCESS,
            /* Network */
            SEND_PACKET,
            RECV_PACKET,
            __DUMMY1,
            __DUMMY2,
            __DUMMY3,
            __DUMMY4,
            __DUMMY5,
            __DUMMY6,
            __DUMMY7,
            __DUMMY8,
            __DUMMY9,
            __DUMMY10,
            __DUMMY11,
            __DUMMY12,
            __DUMMY13,
            __DUMMY14,
            __DUMMY15,
            __DUMMY16,
            __DUMMY17,
            __DUMMY18,
            __DUMMY19,
            __DUMMY20,
            __DUMMY21,
            __DUMMY22,
            __RESERVED3,
            __RESERVED4
        };
        
        public static Dictionary<string, uint> accessInfo = new Dictionary<string, uint>();

        public static bool SetPermission(string path, uint permission)
        {
            bool ret = (AgentController.SetPermission(path, permission) == 0);
            if (ret)
                accessInfo[path] = permission;
            return ret;
        }
    }
}
