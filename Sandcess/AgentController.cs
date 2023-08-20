using System.Diagnostics;

namespace Sandcess
{
	internal class AgentController
	{
		public AgentController() { }


		private static void StartAgent(List<string> argumentList)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("C:\\Sandcess\\Agent\\Agent.exe");
				foreach (string arg in argumentList)
					processStartInfo.ArgumentList.Add(arg);
				Process.Start(processStartInfo);
			}
			catch { }
		}

		private static int StartAgentAndWaitForExit(List<string> argumentList)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("C:\\Sandcess\\Agent\\Agent.exe");
				processStartInfo.UseShellExecute = false;
				foreach (string arg in argumentList)
					processStartInfo.ArgumentList.Add(arg);
				Process process = Process.Start(processStartInfo);
				process.WaitForExit();
				return process.ExitCode;
			}
			catch { }
			return -1;
		}

		public static int SetPermission(string path, uint permission)
		{
			path = FileUtils.DosPathToNtPath(path);
			permission |= 0xc0000003;
			return StartAgentAndWaitForExit(new List<string> {
				"--SetPermission",
				path,
				(Convert.ToChar((ushort)(permission >> 16)).ToString() + Convert.ToChar((ushort)(permission & 0xffff)).ToString())
			});
		}

		public static int CreateContainer(int containerId)
		{
			return StartAgentAndWaitForExit(new List<string> {
				"--CreateContainer",
				containerId.ToString(),
				containerId.ToString()
			});
		}

		public static int DeleteContainer(int containerId)
		{
			return StartAgentAndWaitForExit(new List<string> {
				"--DeleteContainer",
				containerId.ToString(),
				containerId.ToString()
			});
		}

		public static int AddTargetPath(int containerId, string path)
		{
			return StartAgentAndWaitForExit(new List<string> {
				"--AddTargetPath",
				containerId.ToString(),
				FileUtils.DosPathToNtPath(path)
			});
		}

		public static int DeleteTargetPath(int containerId, string path)
		{
			return StartAgentAndWaitForExit(new List<string> {
				"--DeleteTargetPath",
				containerId.ToString(),
				FileUtils.DosPathToNtPath(path)
			});
		}

		public static int AddAccessiblePath(int containerId, string path)
		{
			return StartAgentAndWaitForExit(new List<string> {
				"--AddAccessiblePath",
				containerId.ToString(),
				FileUtils.DosPathToNtPath(path)
			});
		}

		public static int DeleteAccessiblePath(int containerId, string path)
		{
			return StartAgentAndWaitForExit(new List<string> {
				"--DeleteAccessiblePath",
				containerId.ToString(),
				FileUtils.DosPathToNtPath(path)
			});
		}

		public static void ShowDefaultToast(string content)
		{
			StartAgent(new List<string> {
				"--ShowDefaultToast",
				content
			});
		}
	}
}
