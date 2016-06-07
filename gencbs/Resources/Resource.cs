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
        public ResourceType type { get;  set; }
        public String name;
        public int id{get;  set;}
        public int efficiency { get; set; }
        public int costPerHour { get; set; }
        public LinkedList<timeSlot> availability = new LinkedList<timeSlot>();

        public LinkedList<CalenderSlot> roster { get; set; }     
        
        public LinkedList<timeSlot> BookedTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="efficiency"></param>
        public Resource(String name, ResourceType type, int efficiency = 50, int costPerHour = 500)
        {
            Interlocked.Increment(ref nextId);  //Increment the nextId variable in a thread safe manner
            this.id = nextId;   //add Id to the Resource object

            this.name = name;
            this.type = type;
            this.efficiency = efficiency;
            this.costPerHour = costPerHour;
       
            BookedTime = new LinkedList<timeSlot>();
            this.BookedTime = new LinkedList<timeSlot>();
            //this.updateAvailabilityList();
        }



        public Resource()
        {
            // TODO: Complete member initialization
        }



        /// <summary>
        /// update the availability list by checking the bookde list and roster of the resource
        /// </summary>
        public void updateAvailabilityList()
        {
            availability.Clear(); //remove all nodes of the availabilty list
            
            LinkedList<timeSlot> tempList = new LinkedList<timeSlot>();
            timeSlot tempSlot = new timeSlot();
            
            //***do something for the null booked list.

            LinkedListNode<timeSlot> node = BookedTime.First;
            while(node != null)
            {
                tempSlot.startTime = node.Value.endTime;
                node = node.Next;
                if(node == null)
                {
                    tempSlot.endTime = tempSlot.startTime.AddMonths(3); //make the resource available for few months ahead from last booking
                }
                else tempSlot.endTime = node.Value.startTime;
                tempList.AddLast(tempSlot);
            }

            //now intersect tempSLot with calander of the resource

            node = tempList.First;
            timeSlot availableSlot = new timeSlot();

            while (node != null)
            {
                foreach (CalenderSlot slot in roster)
                {
                    availableSlot = slot.intersect(node.Value);
                    if (availableSlot == null) continue;

                    availability.AddLast(availableSlot);

                    if (availableSlot.endTime < node.Value.endTime)
                    {
                        node.Value.endTime = availableSlot.endTime;
                        tempSlot.startTime = availableSlot.endTime;
                        tempSlot.endTime = node.Value.endTime;

                        tempList.AddAfter(node, tempSlot);
                        //continue;
                    }
                    break; //comes here only the available slot ends with the  

                }
                node = node.Next;
            }
        }

        /// <summary>
        /// get the cost of this resource considering diffrent parameters
        /// </summary>
        /// <returns></returns>
        public int getCost(TimeSpan duration)
        {
            int setUpCost = type.setupCost;
            int timeCost = this.costPerHour * duration.Hours * (100 / this.efficiency);
            int totalCost = setUpCost + timeCost;


            return totalCost;        
        }

        /// <summary>
        /// checking availability of the resource going through the BookedTimes linked list
        /// </summary>
        /// <param name="start">after this time, resource needs to be use</param>
        /// <param name="timeSpan">time period 100% efficient resource should free</param>
        /// <returns></returns>
        public bool isAvailable(DateTime start, TimeSpan timeSpan)
        {
            bool isAvailable = false;

            foreach (timeSlot slot in availability)
            {
                isAvailable = slot.isFree(start, new TimeSpan(0, (int)(timeSpan.TotalMinutes * 100 / efficiency), 0) );
                if (isAvailable) break;
            }
            //check availability linked list
            
            return isAvailable;
        }

        /// <summary>
        /// intersect availability list of this resource with any given linked list of timeslots.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public LinkedList<timeSlot> intersectAvailabilityList(LinkedList<timeSlot> list)
        {
            if (list == null) return this.availability;
            LinkedList<timeSlot> result = new LinkedList<timeSlot>();

            LinkedListNode<timeSlot> node = list.First;

            foreach (timeSlot slot in this.availability)
            {
                while (node != null)
                {
                    if (slot.endTime <= node.Value.startTime) break;
                    if (node.Value.endTime <= slot.startTime)
                    {
                        node = node.Next;
                        continue;
                    }
                    result.AddLast( slot.intersect(node.Value));
                }
                if (node == null) break;
            }

            return result;
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

                node = BookedTime.First;                       

            while (node != null)
            {
                if (node.Value.StartTime > startTime)
                {
                    //roster.AddBefore(node, timeSlotNode);
                    break;
                }
                node = node.Next;
            }
        }

    }
}
