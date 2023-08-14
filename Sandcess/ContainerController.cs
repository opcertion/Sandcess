using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sandcess
{
	internal class ContainerController
	{
		private const string CONTAINER_INFO_SAVE_PATH = @"C:\Sandcess\CONTAINER_INFO.JSON";
        [Serializable]
        public struct CONTAINER_INFO
		{
			private static uint containerCount = 0u;
			private readonly uint containerId;
			public List<string> targetPathList;
			public List<string> accessiblePathList;

			public CONTAINER_INFO()
			{
				containerId = containerCount;
				containerCount += 1;
				targetPathList = new List<string>();
				accessiblePathList = new List<string>();
			}

			public static uint GetContainerCount() { return containerCount; }

			public readonly uint GetContainerId() { return containerId; }
		}
		private static Dictionary<string, CONTAINER_INFO> containerInfo = new Dictionary<string, CONTAINER_INFO>();

		public static bool CreateContainer(string container)
		{
			if (AgentController.CreateContainer(container) != 0)
				return false;
			containerInfo[container] = new CONTAINER_INFO();
			return true;
		}

        public static bool DeleteContainer(string container)
        {
            if (AgentController.DeleteContainer(container) != 0)
                return false;
            containerInfo.Remove(container);
			return true;
        }

        public static bool AddTargetPath(string container, string path)
		{
			if (AgentController.AddTargetPath(container, path) != 0)
				return false;
			containerInfo[container].targetPathList.Add(path);
			return true;
		}

		public static bool DeleteTargetPath(string container, string path)
		{
			if (AgentController.DeleteTargetPath(container, path) != 0)
				return false;
			containerInfo[container].targetPathList.Remove(path);
			return true;
		}

        public static bool AddAccessiblePath(string container, string path)
        {
			if (AgentController.AddAccessiblePath(container, path) != 0)
				return false;
            containerInfo[container].accessiblePathList.Add(path);
			return true;
        }

        public static bool DeleteAccessiblePath(string container, string path)
        {
			if (AgentController.DeleteAccessiblePath(container, path) != 0)
				return false;
            containerInfo[container].accessiblePathList.Remove(path);
			return true;
        }

        public static CONTAINER_INFO GetContainerInfo(string container)
		{
			return (containerInfo.ContainsKey(container) ? containerInfo[container] : new CONTAINER_INFO());
		}

		public static bool IsExistsContainer(string container)
		{
			return (containerInfo.ContainsKey(container));
		}

        public static bool IsExistsTargetPath(string container, string path)
        {
            return (containerInfo[container].targetPathList.Contains(path));
        }

        public static bool IsExistsAccessiblePath(string container, string path)
        {
            return (containerInfo[container].accessiblePathList.Contains(path));
        }

        public static List<string> GetContainerList()
		{
			return new List<string>(containerInfo.Keys);
		}

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

        public static List<string> GetContainerListByAccessiblePath(string path)
        {
            List<string> ret = new List<string>();

            foreach (string containerName in containerInfo.Keys)
            {
                if (containerInfo[containerName].accessiblePathList.FindIndex(target => path.StartsWith(target)) != -1)
                    ret.Add(containerName);
            }
            return ret;
        }

        public static void SaveContainerInfo()
		{
			try
			{
                StreamWriter streamWriter = new StreamWriter(CONTAINER_INFO_SAVE_PATH);
                streamWriter.Write(JsonConvert.SerializeObject(containerInfo));
				streamWriter.Close();
            }
			catch { MessageBoxController.ShowError("Failed to save container information."); }
        }

        public static void LoadContainerInfo()
        {
            try
			{
				StreamReader streamReader = new StreamReader(CONTAINER_INFO_SAVE_PATH);
				containerInfo = JsonConvert.DeserializeObject<Dictionary<string, CONTAINER_INFO>>(streamReader.ReadToEnd());
				streamReader.Close();
			}
			catch { containerInfo = new Dictionary<string, CONTAINER_INFO>(); }
        }
    }
}
