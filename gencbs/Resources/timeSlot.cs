using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class timeSlot
    {
        public DateTime startTime{get;set;}
        public DateTime endTime { get; set; }
        private TimeSpan timeSpan;

        public timeSlot(DateTime start ,DateTime end)
        {
            this.startTime = start;
            this.endTime = end;
            this.timeSpan = end - start;
        }

        public timeSlot()
        {
            // TODO: Complete member initialization
        }


        public bool isFree(DateTime from , TimeSpan span)
        {
            bool isfree;

            isfree =  (this.startTime.CompareTo(from) <= 0 ) && (this.timeSpan.CompareTo(span) >= 0);
            return isfree;
        }

        /// <summary>
        /// give the intersection of two timeSlot objects
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public virtual timeSlot intersect(timeSlot slot)
        {
            if ((slot.startTime >= this.endTime) || (slot.endTime <= this.startTime))
            {
                return null;
            }
            timeSlot temp = slot;

            if (this.startTime >= slot.startTime) temp.startTime = this.startTime;

            if (this.endTime <= slot.endTime) temp.endTime = this.endTime;

            return temp;
        }

        public override string ToString()
        {
            String start = this.startTime.ToString();
            String end = this.endTime.ToString();
            return start + " - " + end;
        }

        public DateTime StartTime { get; set; }
        public TimeSpan TimeSpan { get; set; }
    }
}
