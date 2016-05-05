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
            int setUpCost = type.SetUpCost;
            int totalCost = setUpCost;

            return totalCost;        
        }

        public bool isAvailable(DateTime start, TimeSpan timeSpan)
        {
            bool isAvailable = false;

            foreach (timeSlot slot in availability)
            {
                isAvailable = slot.isFree(start, timeSpan);
                if (!isAvailable) break;
            }
            //check availability linked list
            
            return isAvailable;
        }

    }
}
