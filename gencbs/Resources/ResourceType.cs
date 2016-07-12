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
		public LinkedList<Resource> resources { get;  set; }
		public LinkedList<string> _resources { get;  set; }

        public ResourceType(String name, int setupcost = 0)
        {
            this.typeName = name;
            this.setupCost = setupcost;
			this.resources = new LinkedList<Resource> ();
			this._resources = new LinkedList<string> ();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
			if (obj.GetType() != typeof(ResourceType)) return false;

			var rt = (ResourceType) obj;
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

		public void PrepareForSerialization()
		{
//			if (this._resources = null || )
			this._resources = new LinkedList<string> ();
			foreach (var res in this.resources) {
				this._resources.AddLast (res.name);
			}

			this.resources = null;
		}

		public void RestoreFromSerialization()
		{
			foreach (string res in this._resources) {
				resources.AddLast(Data.readResource (res));
			}
		}
               
    }
}
