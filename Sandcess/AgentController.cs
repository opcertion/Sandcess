using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Sandcess
{
	internal class AgentController
	{
		public AgentController() { }


		public static int SetPermission(string path, uint permission)
		{
			path = FileUtils.DosPathToNtPath(path);
			permission |= 0xc0000003;
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("C:\\Sandcess\\Agent\\Agent.exe");
				processStartInfo.UseShellExecute = false;
				processStartInfo.ArgumentList.Add("--SetPermission");
				processStartInfo.ArgumentList.Add(path);
				processStartInfo.ArgumentList.Add(
					(Convert.ToChar((ushort)(permission >> 16)).ToString() + Convert.ToChar((ushort)(permission & 0xffff)).ToString())
				);
				Process process = Process.Start(processStartInfo);
				process.WaitForExit();
				return process.ExitCode;
			}
			catch { }
			return -1;
		}

		public static void ShowDefaultToast(string content)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("C:\\Sandcess\\Agent\\Agent.exe");
				processStartInfo.UseShellExecute = false;
				processStartInfo.ArgumentList.Add("--ShowDefaultToast");
				processStartInfo.ArgumentList.Add(content);
				Process.Start(processStartInfo);
			}
			catch { }
		}
	}
}
