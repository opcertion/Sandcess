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
        }
        public static Dictionary<string, CONTAINER_INFO> containerInfo = new Dictionary<string, CONTAINER_INFO>();

        
    }
}
