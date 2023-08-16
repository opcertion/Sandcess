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
		public const int MAXIMUM_CONTAINER_COUNT = 100;
		public const int MAXIMUM_CONTAINER_ID = MAXIMUM_CONTAINER_COUNT;

		private readonly struct CONTAINER_PATH_INFO
		{
			[JsonProperty] private readonly int containerId;
			[JsonProperty] private readonly List<string> targetPathList;
			[JsonProperty] private readonly List<string> accessiblePathList;

			public CONTAINER_PATH_INFO(int containerId)
			{
				this.containerId = containerId;
				targetPathList = new List<string>();
				accessiblePathList = new List<string>();
			}

			public readonly int GetContainerId()
			{
				return containerId;
			}

			public readonly List<string> GetTargetPathList()
			{
				return targetPathList;
			}

			public readonly void AddTargetPath(string path)
			{
				targetPathList.Add(path);
			}

			public readonly void RemoveTargetPath(string path)
			{
				targetPathList.Remove(path);
			}

			public readonly List<string> GetAccessiblePathList()
			{
				return accessiblePathList;
			}

			public readonly void AddAccessiblePath(string path)
			{
				accessiblePathList.Add(path);
			}

			public readonly void RemoveAccessiblePath(string path)
			{
				accessiblePathList.Remove(path);
			}
		}
		private struct PATH_TO_CONTAINER_INFO
		{
			[JsonProperty] private readonly bool[] containerActivateState = new bool[MAXIMUM_CONTAINER_ID + 1];
			public Dictionary<string, CONTAINER_PATH_INFO> info;

			public PATH_TO_CONTAINER_INFO()
			{
				info = new Dictionary<string, CONTAINER_PATH_INFO>();
			}

			public readonly bool IsContainerActivated(int containerId)
			{
				return containerActivateState[containerId];
			}

			public readonly int GetAvailableContainerId()
			{
				int containerId = 1;
				for (; containerId <= MAXIMUM_CONTAINER_ID; containerId++)
				{
					if (!containerActivateState[containerId])
						return containerId;
				}
				return -1;
			}

			public readonly void SetContainerActivateState(int containerId, bool activate)
			{
				containerActivateState[containerId] = activate;
			}
		}
		private static PATH_TO_CONTAINER_INFO containerInfo = new PATH_TO_CONTAINER_INFO();
		
		public static bool CreateContainer(string container)
		{
			int containerId = containerInfo.GetAvailableContainerId();
			if ((containerId == -1) || (AgentController.CreateContainer(containerId) != 0))
				return false;
			containerInfo.SetContainerActivateState(containerId, true);
			containerInfo.info[container] = new CONTAINER_PATH_INFO(containerId);
			return true;
		}

		public static bool DeleteContainer(string container)
		{
			int containerId = containerInfo.info[container].GetContainerId();
			if (AgentController.DeleteContainer(containerId) != 0)
				return false;
			containerInfo.SetContainerActivateState(containerId, false);
			containerInfo.info.Remove(container);
			return true;
		}

		public static bool AddTargetPath(string container, string path)
		{
			int containerId = containerInfo.info[container].GetContainerId();
			if (AgentController.AddTargetPath(containerId, path) != 0)
				return false;
			containerInfo.info[container].AddTargetPath(path);
			return true;
		}

		public static bool DeleteTargetPath(string container, string path)
		{
			int containerId = containerInfo.info[container].GetContainerId();
			if (AgentController.DeleteTargetPath(containerId, path) != 0)
				return false;
			containerInfo.info[container].RemoveTargetPath(path);
			return true;
		}

		public static bool AddAccessiblePath(string container, string path)
		{
			int containerId = containerInfo.info[container].GetContainerId();
			if (AgentController.AddAccessiblePath(containerId, path) != 0)
				return false;
			containerInfo.info[container].AddAccessiblePath(path);
			return true;
		}

		public static bool DeleteAccessiblePath(string container, string path)
		{
			int containerId = containerInfo.info[container].GetContainerId();
			if (AgentController.DeleteAccessiblePath(containerId, path) != 0)
				return false;
			containerInfo.info[container].RemoveAccessiblePath(path);
			return true;
		}

		public static List<string> GetTargetPathList(string container)
		{
			return (containerInfo.info[container].GetTargetPathList());
		}

		public static List<string> GetAccessiblePathList(string container)
		{
			return (containerInfo.info[container].GetAccessiblePathList());
		}

		public static bool IsExistsContainer(string container)
		{
			return (containerInfo.info.ContainsKey(container));
		}

		public static bool IsExistsTargetPath(string container, string path)
		{
			return (containerInfo.info[container].GetTargetPathList().Contains(path));
		}

		public static bool IsExistsAccessiblePath(string container, string path)
		{
			return (containerInfo.info[container].GetAccessiblePathList().Contains(path));
		}

		public static List<string> GetContainerList()
		{
			return new List<string>(containerInfo.info.Keys);
		}

		public static List<string> GetContainerListByTargetPath(string path)
		{
			List<string> ret = new List<string>();

			foreach (string container in containerInfo.info.Keys)
			{
				if (containerInfo.info[container].GetTargetPathList().FindIndex(target => path.StartsWith(target)) != -1)
					ret.Add(container);
			}
			return ret;
		}

		public static List<string> GetContainerListByAccessiblePath(string path)
		{
			List<string> ret = new List<string>();

			foreach (string container in containerInfo.info.Keys)
			{
				if (containerInfo.info[container].GetAccessiblePathList().FindIndex(target => path.StartsWith(target)) != -1)
					ret.Add(container);
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
				containerInfo = JsonConvert.DeserializeObject<PATH_TO_CONTAINER_INFO>(streamReader.ReadToEnd());
				streamReader.Close();
			}
			catch { containerInfo = new PATH_TO_CONTAINER_INFO(); }
		}
	}
}
