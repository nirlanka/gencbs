using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class Resource
    {
        private ResourceType type;
        private String name;
        private int id;
        private LinkedList<timeSlot> bookedTime;            // 
        private LinkedList<timeSlot> roster;                // 
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
            bookedTime = new LinkedList<timeSlot>();
            roster = new LinkedList<timeSlot>();
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
                isAvailable = slot.isFree(start, timeSpan);
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
