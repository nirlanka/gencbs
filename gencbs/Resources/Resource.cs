using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace gencbs.Resources
{
    class Resource
    {
        private static int nextId = 0;  //this value should changed to the last count of the stored objects
        public ResourceType type;
        public String name;
        public int id{get; private set;}
        public LinkedList<timeSlot> availability;

        private LinkedList<BookedTimeSlot> booked;

        private int efficiency;

        public Resource()
        {
            Interlocked.Increment(ref nextId);  //Increment the nextId variable in a thread safe manner
            this.id = nextId;   //add Id to the Resource object
        }

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
                isAvailable = slot.isFree(start, new TimeSpan(0, (int)(timeSpan.TotalMinutes / efficiency), 0) );
                if (!isAvailable) break;
            }
            //check availability linked list
            
            return isAvailable;
        }

    }
}
