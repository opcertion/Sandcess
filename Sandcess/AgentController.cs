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


		public static string SendDataToDriver(string data)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.FileName = "C:\\Sandcess\\Agent\\Agent.exe";
				process.StartInfo.Arguments = "--send \"" + data + "\"";
				process.Start();

				return process.StandardOutput.ReadToEnd();
			}
			catch { }
			return "";
		}


		public static void ShowDefaultToast(string content)
		{
            try
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "C:\\Sandcess\\Agent\\Agent.exe";
                process.StartInfo.Arguments = "--showDefaultToast \"" + content + "\"";
                process.Start();
            }
            catch { }
        }
	}
}
