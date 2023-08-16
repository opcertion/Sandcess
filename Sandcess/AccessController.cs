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
		public readonly struct ACCESS_INFO
		{
            [JsonProperty] private readonly uint permission;

			public ACCESS_INFO(uint permission)
			{ 
				this.permission = permission;
			}

			public readonly uint GetPermission()
			{
				return permission;
			}
		}
		private struct PATH_TO_ACCESS_INFO
		{
			public Dictionary<string, ACCESS_INFO> info;

			public PATH_TO_ACCESS_INFO()
			{
				info = new Dictionary<string, ACCESS_INFO>();
			}
		}
		private static PATH_TO_ACCESS_INFO pathToAccessInfo = new PATH_TO_ACCESS_INFO();

		public static bool SetPermission(string path, uint permission)
		{
			bool ret = (AgentController.SetPermission(path, permission) == 0);
			if (ret)
				pathToAccessInfo.info[path] = new ACCESS_INFO(permission);
			return ret;
		}

		public static uint GetPermission(string path)
		{
			return (pathToAccessInfo.info.ContainsKey(path) ? pathToAccessInfo.info[path].GetPermission() : (uint)0xffffffff);
		}

		public static List<string> GetPathList()
		{
			return new List<string>(pathToAccessInfo.info.Keys);
		}

		public static void SaveAccessInfo()
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(ACCESS_INFO_SAVE_PATH);
				streamWriter.Write(JsonConvert.SerializeObject(pathToAccessInfo));
				streamWriter.Close();
			}
			catch { MessageBoxController.ShowError("Failed to save access information."); }
		}

		public static void LoadAccessInfo()
		{
			try
			{
				StreamReader streamReader = new StreamReader(ACCESS_INFO_SAVE_PATH);
				pathToAccessInfo = JsonConvert.DeserializeObject<PATH_TO_ACCESS_INFO>(streamReader.ReadToEnd());
				streamReader.Close();
			}
			catch { pathToAccessInfo = new PATH_TO_ACCESS_INFO(); }
		}
	}
}
