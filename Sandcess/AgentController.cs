using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

		public static int CreateContainer(string container)
		{
            return StartAgentAndWaitForExit(new List<string> {
                "--CreateContainer",
                ContainerController.CONTAINER_INFO.GetContainerCount().ToString(),
                container
            });
        }

        public static int DeleteContainer(string container)
        {
            return StartAgentAndWaitForExit(new List<string> {
                "--DeleteContainer",
                ContainerController.GetContainerInfo(container).GetContainerId().ToString(),
                container
            });
        }

        public static int AddTargetPath(string container, string path)
        {
            return StartAgentAndWaitForExit(new List<string> {
                "--AddTargetPath",
                container,
                path
            });
        }

        public static int DeleteTargetPath(string container, string path)
        {
            return StartAgentAndWaitForExit(new List<string> {
                "--DeleteTargetPath",
                container,
                path
            });
        }

        public static int AddAccessiblePath(string container, string path)
        {
            return StartAgentAndWaitForExit(new List<string> {
                "--AddAccessiblePath",
                container,
                path
            });
        }

        public static int DeleteAccessiblePath(string container, string path)
        {
            return StartAgentAndWaitForExit(new List<string> {
                "--DeleteAccessiblePath",
                container,
                path
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
