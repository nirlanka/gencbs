using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class Machine : Resource
    {
        public Machine(String name, ResourceType ResType, int efficiency , int costPerHour)
            : base(name ,ResType,efficiency,costPerHour)
        {

        }
    }
}
