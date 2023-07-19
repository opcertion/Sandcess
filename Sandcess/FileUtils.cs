using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandcess
{
    internal class FileUtils
    {
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
    }
}
