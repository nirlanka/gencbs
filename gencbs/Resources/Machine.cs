using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class Machine : Resource
    {
        public Machine(String name, ResourceType ResType, int efficiency)
            : base(name ,ResType,efficiency)
        {

        }
    }
}
