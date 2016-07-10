using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    public class TimeSlot
    {
        public DateTime startTime{get;set;}
        public DateTime endTime { get; set; }
        private TimeSpan timeSpan;

        public TimeSlot(DateTime start, DateTime end)
        {
            if (start > end) throw new ArgumentException("Wrong parametes");
            this.startTime = start;
            this.endTime = end;
            this.timeSpan = end - start;
        }

        public TimeSlot()
        {
            //this.startTime = null;
            //this.endTime = null;
        }


        public bool IsFree(DateTime from, TimeSpan span)
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
        public virtual TimeSlot intersect(TimeSlot slot)
        {
            Console.WriteLine("timeslot");
            if ((slot.startTime >= this.endTime) || (slot.endTime <= this.startTime))
            {
                return null;
            }
            TimeSlot temp = slot;

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
