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
        public ResourceType type { get; private set; }
        public String name;
        public int id{get; private set;}

        public LinkedList<timeSlot> availability;

        public LinkedList<BookedTimeSlot> bookedList;
         // 
        private LinkedList<CalenderSlot> roster;      
        private int efficiency = 100;
        public LinkedList<timeSlot> BookedTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="efficiency"></param>
        public Resource(ResourceType type, int efficiency)
        {
            Interlocked.Increment(ref nextId);  //Increment the nextId variable in a thread safe manner
            this.id = nextId;   //add Id to the Resource object

            this.type = type;
            this.efficiency = efficiency;
       
            BookedTime = new LinkedList<timeSlot>();
            this.BookedTime = new LinkedList<timeSlot>();
        }

        /// <summary>
        /// update the availability list by checking the bookde list and roster of the resource
        /// </summary>
        private void getAvailabilityList()
        {
            LinkedList<timeSlot> tempList = new LinkedList<timeSlot>();
            timeSlot tempSlot = new timeSlot();
            
            LinkedListNode<timeSlot> node = BookedTime.First;
            while(node == null)
            {
                tempSlot.startTime = node.Value.endTime;
                node = node.Next;
                if(node == null)
                {
                    tempSlot.endTime = tempSlot.startTime.AddMonths(3); //make the resource available for few months ahead from last booking
                }
                tempSlot.endTime = node.Value.startTime;
                tempList.AddLast(tempSlot);
            }

            


            //LinkedListNode<timeSlot> rosterNode = roster.First;
            //foreach (timeSlot bookedSlot in BookedTime)
            //{
            //    while(true)
            //    {
            //        timeSlot rosterSlot = rosterNode.Value;

            //        if(bookedSlot.startTime.DayOfWeek >= rosterSlot.startTime.DayOfWeek)
            //        {
            //            if()
            //            {
            //            }
            //        }

            //        rosterNode = rosterNode.Next;
            //        if (rosterNode == null)
            //        {
            //            rosterNode = roster.First;
            //        }
            //    }

            //}
        }

        /// <summary>
        /// get the cost of this resource considering diffrent parameters
        /// </summary>
        /// <returns></returns>
        public int getCost()
        {
            int setUpCost = type.setupCost;
            int totalCost = setUpCost;


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

            foreach (timeSlot slot in BookedTime)
            {
                isAvailable = slot.isFree(start, new TimeSpan(0, (int)(timeSpan.TotalMinutes * 100 / efficiency), 0) );
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
