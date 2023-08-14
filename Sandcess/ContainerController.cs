using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sandcess
{
	internal class ContainerController
	{
		private const string CONTAINER_INFO_SAVE_PATH = @"C:\Sandcess\CONTAINER_INFO.DAT";
        [Serializable]
        public struct CONTAINER_INFO
		{
			public List<string> targetPathList;
			public List<string> accessiblePathList;

			public CONTAINER_INFO()
			{
				targetPathList = new List<string>();
				accessiblePathList = new List<string>();
			}
		}
		public static Dictionary<string, CONTAINER_INFO> containerInfo = new Dictionary<string, CONTAINER_INFO>();

		public static List<string> GetContainerListByTargetPath(string path)
		{
			List<string> ret = new List<string>();

			foreach (string containerName in containerInfo.Keys)
			{
				if (containerInfo[containerName].targetPathList.FindIndex(target => path.StartsWith(target)) != -1)
					ret.Add(containerName);
			}
			return ret;
		}

		public static void SaveContainerInfo()
		{
            BinaryFormatter binaryFormatter = new BinaryFormatter();
			try
			{
                using Stream stream = File.Open(CONTAINER_INFO_SAVE_PATH, FileMode.Create);
                binaryFormatter.Serialize(stream, containerInfo);
                stream.Close();
            }
			catch
			{
                MessageBox.Show(
                    "Failed to save container information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public static void LoadContainerInfo()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
			try
			{
				using Stream stream = File.Open(CONTAINER_INFO_SAVE_PATH, FileMode.Open);
				containerInfo = (Dictionary<string, CONTAINER_INFO>)binaryFormatter.Deserialize(stream);
				stream.Close();
			}
			catch { containerInfo = new Dictionary<string, CONTAINER_INFO>(); }
        }
    }
}
