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


        private LinkedList<timeSlot> bookedTime;            // 
        private LinkedList<timeSlot> roster;      
        private int efficiency;
        public LinkedList<timeSlot> BookedTime
        {
            get { return bookedTime; }

        }
        public String Name { get; set; }
        public int Id { get; set; }
        public ResourceType Type { get; set; }

        public Resource()
        {
            Interlocked.Increment(ref nextId);  //Increment the nextId variable in a thread safe manner
            this.id = nextId;   //add Id to the Resource object
       
            bookedTime = new LinkedList<timeSlot>();
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

            foreach (timeSlot slot in bookedTime)
            {
                isAvailable = slot.isFree(start, new TimeSpan(0, (int)(timeSpan.TotalMinutes / efficiency), 0) );
                if (!isAvailable) break;
            }
            //check availability linked list
            
            return isAvailable;
        }


        /// <summary>
        /// Add new timeSlot to the linked list
        /// </summary>
        /// <param name="startTime"> start time of the timeSlot</param>
        /// <param name="endTime"> end time of the timeSlot</param>
        /// </param>
        public void insertTimeSlot(DateTime startTime, DateTime endTime)
        {
            timeSlot timeSlotNode = new timeSlot(startTime, endTime);
            LinkedListNode<timeSlot> node = null;

                node = bookedTime.First;                       

            while (node != null)
            {
                if (node.Value.StartTime > startTime)
                {
                    roster.AddBefore(node, timeSlotNode);
                    break;
                }
                node = node.Next;
            }
        }

    }
}
