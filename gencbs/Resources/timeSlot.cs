using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class timeSlot
    {
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan timeSpan;

        public timeSlot(DateTime start ,DateTime end)
        {
            this.startTime = start;
            this.endTime = end;
            this.timeSpan = end - start;
        }

        public bool isFree(DateTime from , TimeSpan span)
        {
            bool isfree;

            isfree =  (this.startTime.CompareTo(from) <= 0 ) && (this.timeSpan.CompareTo(span) >= 0);
            return isfree;
        }
    }
}
