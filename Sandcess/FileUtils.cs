using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

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
    }
}
