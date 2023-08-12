using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandcess
{
    internal class ContainerController
    {
        public struct CONTAINER_INFO
        {
            public List<string> targetFileList;
            public List<string> accessibleFolderList;

            public CONTAINER_INFO()
            {
                targetFileList = new List<string>();
                accessibleFolderList = new List<string>();
            }
        }
        public static Dictionary<string, CONTAINER_INFO> containerInfo = new Dictionary<string, CONTAINER_INFO>();

        public static List<string> GetContainerListByTargetFile(string path)
        {
            List<string> ret = new List<string>();

            foreach (string containerName in containerInfo.Keys)
            {
                if (containerInfo[containerName].targetFileList.IndexOf(path) != -1)
                    ret.Add(containerName);
            }
            return ret;
        }
    }
}
