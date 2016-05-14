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
            timeSlot temp = slot;

            //creates the corresponding slot on the same week
            int startGap = slot.startTime.DayOfWeek - this.startTime.DayOfWeek;
            int endGap = slot.endTime.DayOfWeek - this.endTime.DayOfWeek;
            timeSlot rosterTemp = slot;
            rosterTemp.startTime.AddDays(startGap);
            rosterTemp.endTime.AddDays(endGap);

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
