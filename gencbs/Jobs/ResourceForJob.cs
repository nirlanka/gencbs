using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gencbs.Resources;

namespace gencbs.Jobs
{
    class ResourceForJob
    {
        //have to consider the situation of requiring more than one resource from one type
        public ResourceType resourceType;
        public Resource allocated_resource; //add a resource after scheduling
        public ResourceForJob(ResourceType type)
        {
            this.resourceType = type;
        }
    }
}
