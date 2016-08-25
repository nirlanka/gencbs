using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class Labour : Resource
    {
        public Labour(String name, ResourceType type, int efficiency = 50, int costPerHour = 500)
            : base(name, type, efficiency,costPerHour)
        {

        }

    }
}
