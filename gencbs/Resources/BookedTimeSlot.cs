using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Resources
{
    class BookedTimeSlot : timeSlot
    {
        public int bookedJobId { get; set; }

        public BookedTimeSlot(DateTime start, DateTime end)
            : base(start, end)
        {

        }
    }
}
