using System.Diagnostics;
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sandcess
{
	internal class FileUtils
	{
		[DllImport("kernel32.dll", EntryPoint = "QueryDosDevice")]
		private extern static uint QueryDosDevice(string lpDeviceName, StringBuilder lpszVolumeName, uint ccBufferLength);

		public static bool IsExists(string path)
		{
			return (IsDirectory(path) ? Directory.Exists(path) : File.Exists(path));
		}

		public static bool IsDirectory(string path)
		{
			return path.EndsWith("\\");
		}

		public static string GetFileName(string path)
		{
			return path.Split("\\").Last();
		}

		public static string DosPathToNtPath(string path)
		{
			StringBuilder sb = new StringBuilder(1024);
			QueryDosDevice(Path.GetPathRoot(path).Replace("\\", ""), sb, 1024);
			return string.Concat(sb.ToString(), path.AsSpan(2));
		}

		public static string GetDigitalSignature(string path)
		{
			try
			{
				Runspace runspace = RunspaceFactory.CreateRunspace();
				runspace.Open();

				Pipeline pipeline = runspace.CreatePipeline();
				pipeline.Commands.AddScript("Get-PfxCertificate \"" + path + "\"");

				X509Certificate2 certificate = (X509Certificate2)(pipeline.Invoke()[0].BaseObject);
				runspace.Close();

				return (certificate.Subject.Substring(3, certificate.Subject.IndexOf(",") - 3));
			}
			catch { }
			return "";
		}

		public static void OpenFileExplorer(string path)
		{
			try
			{
                if (!IsExists(path))
				{
					MessageBoxController.ShowError("File not found.");
					return;
				}
                Process.Start("explorer.exe", ("/select, " + "\"" + path + "\""));
			}
			catch { MessageBoxController.ShowError("Failed to open file explorer."); }
		}
	}
}
