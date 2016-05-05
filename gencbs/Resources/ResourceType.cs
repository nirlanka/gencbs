using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class ResourceType
    {
        private enum resourceType { Doctor, Nurse, OperationTheator };

        private int setUpCost;

        public int SetUpCost
        {
            get { return setUpCost; }
            set { setUpCost = value; }
        }        
    }
}
