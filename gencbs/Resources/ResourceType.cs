using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class ResourceType
    {
        public String name { get; private set; }
        public int setupCost { get; private set; }

        public ResourceType(String name)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            ResourceType rt = obj as ResourceType;
            return (this.name == rt.name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
               
    }
}
