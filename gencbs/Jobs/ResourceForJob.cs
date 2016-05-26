using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gencbs.Resources;

namespace gencbs.Jobs
{
    class ResourceForJob
    {
        public ResourceType resourceType;
        public Resource allocated_resource; //add a resource after scheduling
    }
}
