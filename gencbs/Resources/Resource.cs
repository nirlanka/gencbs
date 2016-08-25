using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using gencbs;

namespace gencbs.Resources
{
    public class Resource
    {
        private static int nextId = 0;  //this value should changed to the last count of the stored objects
        public ResourceType type { get;  set; }
		public string _type = null;
        public String name;
        public int id{get;  set;}
        public int efficiency { get; set; }
        public int costPerHour { get; set; }
        public LinkedList<TimeSlot> availability = new LinkedList<TimeSlot>();

        public LinkedList<CalenderSlot> roster { get; set; }     
		public string _roster = null;
        
        public LinkedList<TimeSlot> BookedTime { get; set; }
		public string _bookedTime = null;


        public Resource (String name, ResourceType type, int efficiency = 50, int costPerHour = 500)
        {
            Interlocked.Increment(ref nextId);  //Increment the nextId variable in a thread safe manner
            this.id = nextId;   //add Id to the Resource object

            this.name = name;
            ///here resource type maybe not necessory since we keep resources according to their type
            this.type = type;
            this.efficiency = efficiency;
            this.costPerHour = costPerHour;
       
//            BookedTime = new LinkedList<TimeSlot>();
            this.BookedTime = new LinkedList<TimeSlot>();
            //this.updateAvailabilityList();
        }
			
        public Resource()
        {
            // TODO: Complete member initialization
        }

        /// <summary>
        /// update the availability list after a resource is allocated to a job.
        /// </summary>
        public void updateAvailabilityList()
        {
            availability.Clear(); //remove all nodes of the availabilty list
            
            LinkedList<TimeSlot> tempList = new LinkedList<TimeSlot>();
            TimeSlot tempSlot = new TimeSlot();
            
            // do something for the null booked list.

            LinkedListNode<TimeSlot> node = BookedTime.First;
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

            //when booked time list is null
            //add 3 months from the current date
            if (node == null)
            {
                tempSlot.startTime = DateTime.Now;
                tempSlot.endTime = tempSlot.startTime.AddMonths(3); //make the resource available for few months ahead from last booking
                tempList.AddLast(tempSlot);
            }

            //now intersect tempSLot with calander of the resource

            node = tempList.First;
            TimeSlot availableSlot = new TimeSlot();

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

        public int getCost(TimeSpan duration)
        {
            int setUpCost = type.setupCost;
            int timeCost = this.costPerHour * duration.Hours * (100 / this.efficiency);
            int totalCost = setUpCost + timeCost;


            return totalCost;        
        }

        /// <summary>
        /// check whether the resource is available for a given time period after specific time
        /// </summary>
        /// <param name="start"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public bool isAvailable(DateTime start, TimeSpan timeSpan)
        {
            bool isAvailable = false;

            foreach (TimeSlot slot in availability)
            {
                isAvailable = slot.IsFree(start, new TimeSpan(0, (int)(timeSpan.TotalMinutes * 100 / efficiency), 0) );
                if (isAvailable) break;
            }
            //check availability linked list
            
            return isAvailable;
        }

        /// <summary>
        /// intesect two availability lists to get common periods
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public LinkedList<TimeSlot> intersectAvailabilityList(LinkedList<TimeSlot> list)
        {
            if (list == null) return this.availability;
            LinkedList<TimeSlot> result = new LinkedList<TimeSlot>();

            LinkedListNode<TimeSlot> node = list.First;

            foreach (TimeSlot slot in this.availability)
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
        /// insert a time slot to the bookde list
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public void bookTimeSlot(DateTime startTime, DateTime endTime)
        {
            //assume that someone does not try to book a time slot that was booked before,
            //if that occurs should throw an exception
            TimeSlot TimeSlotNode = new TimeSlot(startTime, endTime);
            LinkedListNode<TimeSlot> node = null;

            node = BookedTime.First;
            if (node == null)
            {
                this.BookedTime.AddLast(TimeSlotNode);
            }
            while (node != null)
            {
                if (node.Value.StartTime > startTime)
                {
                    this.BookedTime.AddBefore(node, TimeSlotNode); //add it infront of the current node,
                                                                   //for this it should be gurantee that two slots are not clashed
                    break;
                }
                node = node.Next;
            }


        }

		public void PrepareForSerialization()
		{
			if (this._roster == null) {
				// TODO: Introduce better (unique?) hash function
				this._roster = this.GetHashCode ().ToString ();
				gencbs.Data.addRoster (this._roster, this.roster);
			}
			this.roster = null;
			this.availability = null; // TODO: Check if `availability` needs to be stored
			this._type = this.type.typeName;
			this.type = null;
		}

		public void RestoreFromSerialization()
		{
			this.roster = Data.getRoster (this._roster);
			this.type = Data.getResourceType (this._type);
		}

    }
}
