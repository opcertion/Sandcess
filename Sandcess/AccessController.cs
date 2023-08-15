using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sandcess
{
    internal class AccessController
    {
        private const string ACCESS_INFO_SAVE_PATH = @"C:\Sandcess\ACCESS_INFO.JSON";
        enum ACCESS_TYPE
        {
            /* File System */
            READ_FILE = 2,
            WRITE_FILE,
            MOVE_FILE,
            /* Process */
            CREATE_PROCESS,
            /* Network */
            SEND_PACKET,
            RECV_PACKET,
        };
        private static Dictionary<string, uint> accessInfo = new Dictionary<string, uint>();

        public static bool SetPermission(string path, uint permission)
        {
            bool ret = (AgentController.SetPermission(path, permission) == 0);
            if (ret)
                accessInfo[path] = permission;
            return ret;
        }

        public static uint GetPermission(string path)
        {
            return (accessInfo.ContainsKey(path) ? accessInfo[path] : (uint)0xffffffff);
        }

        public static List<string> GetPathList()
        {
            return new List<string>(accessInfo.Keys);
        }

        public static void SaveAccessInfo()
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(ACCESS_INFO_SAVE_PATH);
                streamWriter.Write(JsonConvert.SerializeObject(accessInfo));
                streamWriter.Close();
            }
            catch { MessageBoxController.ShowError("Failed to save access information."); }
        }

        public static void LoadAccessInfo()
        {
            try
            {
                StreamReader streamReader = new StreamReader(ACCESS_INFO_SAVE_PATH);
                accessInfo = JsonConvert.DeserializeObject<Dictionary<string, uint>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            catch { accessInfo = new Dictionary<string, uint>(); }
        }
    }
}
