using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sandcess
{
    internal class AccessController
    {
        private const string ACCESS_INFO_SAVE_PATH = @"C:\Sandcess\ACCESS_INFO.DAT";
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
        
        public static Dictionary<string, uint> accessInfo = new Dictionary<string, uint>();

        public static bool SetPermission(string path, uint permission)
        {
            bool ret = (AgentController.SetPermission(path, permission) == 0);
            if (ret)
                accessInfo[path] = permission;
            return ret;
        }

        public static void SaveAccessInfo()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                using Stream stream = File.Open(ACCESS_INFO_SAVE_PATH, FileMode.Create);
                binaryFormatter.Serialize(stream, accessInfo);
                stream.Close();
            }
            catch
            {
                MessageBox.Show(
                    "Failed to save access information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public static void LoadAccessInfo()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                using Stream stream = File.Open(ACCESS_INFO_SAVE_PATH, FileMode.Open);
                accessInfo = (Dictionary<string, uint>)binaryFormatter.Deserialize(stream);
                stream.Close();
            }
            catch { accessInfo = new Dictionary<string, uint>(); }
        }
    }
}
