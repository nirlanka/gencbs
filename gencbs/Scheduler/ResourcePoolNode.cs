using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;

namespace gencbs.Scheduler
{
    class ResourcePoolNode
    {
        public ResourceType type { get; set; }
        public LinkedList<Resource> resourceList { get; set; }

        public ResourcePoolNode(ResourceType type)
        {
            this.type = type;
            resourceList = new LinkedList<Resource>();
        }
    }
}
