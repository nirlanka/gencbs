using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Jobs;
using gencbs.Resources;

namespace gencbs.Scheduler.DeterministicScheduler
{
    class Schedular
    {
        public static LinkedList<ResourcePoolNode> resourcePool = PreSchedule.createResourcePool();


        public static LinkedList<ResourcePoolNode> resourcePoolForJob(Job job)
        {
            LinkedList<ResourcePoolNode> resourcePoolForJob = new LinkedList<ResourcePoolNode>();

            foreach (ResourcePoolNode node in resourcePool)
            {

            }

            return resourcePoolForJob;
        }

        public static Job scheduleJob(Job job)
        {
            foreach (ResourceForJob node in job.requredResources)
            {

            }

            return job;
        }
    }
}
