using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    public class ResourceType
    {
        public String typeName { get;  set; }
        public int setupCost { get;  set; }

        public ResourceType(String name, int setupcost = 0)
        {
            this.typeName = name;
            this.setupCost = setupcost;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            ResourceType rt = obj as ResourceType;
            return (this.typeName == rt.typeName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

		public override string ToString ()
		{
			return typeName;
		}
               
    }
}
