using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace gencbs.Jobs
{
    class Job
    {
        private static int nextId= 0;
        private DateTime EPST; //Earliest Possible Start time
        private DateTime dueDate;
        private TimeSpan duration;
        public int jobID{ get; private set;}

        public String jobName { get; private set; }
        public LinkedList<res> resources;


        public Job()
        {
            Interlocked.Increment(ref nextId);
            this.jobID = nextId;
        }

        //create a resource pool for the job


        //get the resource list
        public List<String> getResourceList()
        {
            List<String> list = new List<string>();
            foreach(res r in resources)
            {
                list.Add(r.resourceType);
            }
            return list;
        }
    }
}
