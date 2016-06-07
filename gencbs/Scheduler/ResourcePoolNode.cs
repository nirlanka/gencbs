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
        private Random random = new Random();

        public ResourcePoolNode(ResourceType type)
        {
            this.type = type;
            resourceList = new LinkedList<Resource>();
        }


        /// <summary>
        /// return a random resource of this resource type
        /// </summary>
        /// <returns></returns>
        public Resource getRandomResource(){
            if (resourceList.Count == 0) return null;
            int ran = random.Next(resourceList.Count);

            return resourceList.ElementAt(ran);
        }
    }
}
