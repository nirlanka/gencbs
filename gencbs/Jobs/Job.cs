using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs.Jobs
{
    class Job
    {
        private DateTime EPST; //Earliest Possible Start time
        private DateTime dueDate;
        private TimeSpan duration;
        private int jobID;
        private String jobName;
        public LinkedList<res> resources;
    }
}
