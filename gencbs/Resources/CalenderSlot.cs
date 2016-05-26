using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class CalenderSlot : timeSlot
    {
        DayOfWeek day;

        public CalenderSlot(DateTime start, DateTime end):base (start,end)
        {
            this.day = start.DayOfWeek;
        }

        /// <summary>
        /// returns the intersetion of a calander slot and a timeslot
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public override timeSlot intersect(timeSlot slot)
        {
            timeSlot temp = new timeSlot(slot.startTime,slot.endTime);
            //Console.WriteLine(slot);

            //creates the corresponding slot on the same week
            int startGap =  this.startTime.DayOfWeek - slot.startTime.DayOfWeek;
            int endGap = this.endTime.DayOfWeek - slot.endTime.DayOfWeek;

            timeSlot rosterTemp = new timeSlot(slot.startTime, slot.endTime);
           
            rosterTemp.startTime = rosterTemp.startTime.AddDays(startGap).Add(this.startTime.TimeOfDay - slot.startTime.TimeOfDay);
            rosterTemp.endTime = rosterTemp.endTime.AddDays(endGap).Add(this.endTime.TimeOfDay - slot.endTime.TimeOfDay);


            if( (slot.startTime >= rosterTemp.endTime) || (slot.endTime <= rosterTemp.startTime) )
            {
                return null;
            }

            if (slot.startTime < rosterTemp.startTime) temp.startTime = rosterTemp.startTime;
            if (slot.endTime > rosterTemp.endTime) temp.endTime = rosterTemp.endTime;
            
            return temp;
        }
    }
}
