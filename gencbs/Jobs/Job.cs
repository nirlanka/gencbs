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
        public DateTime EPST{ get; set;} //Earliest Possible Start time
        public DateTime dueDate { get; set; }
        public TimeSpan duration { get; set; }
        public int jobID{ get; set;}

        public String jobName { get; set; }
        public LinkedList<ResourceForJob> requredResources { get; set; }


        public Job()
        {
            Interlocked.Increment(ref nextId);
            this.jobID = nextId;
        }

        //create a resource pool for the job
        public LinkedList<LinkedList<Resources.Resource>> createResourcePool()
        {
            return null;
        }




        ////get the resource list
        //public List<String> getResourceList()
        //{
        //    List<String> list = new List<string>();
        //    foreach(res r in requredResources)
        //    {
        //        list.Add(r.resourceType);
        //    }
        //    return list;
        //}
    }
}
