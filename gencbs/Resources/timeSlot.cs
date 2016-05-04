using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class timeSlot
    {
        public DateTime startTime;
        public DateTime endTime;

        public timeSlot(DateTime start ,DateTime end)
        {
            startTime = start;
            endTime = end;
        }
    }
}
