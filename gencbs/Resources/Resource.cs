using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class Resource
    {
        public ResourceType type;
        public String name;
        public int id;
        public LinkedList<timeSlot> availability;

        public int getCost()
        {
            int cost = 0;

            return cost;        
        }

        public bool isAvailable(timeSlot timeToCheck)
        {
            bool isAvailable = false;


            
            return isAvailable;
        }

    }
}
