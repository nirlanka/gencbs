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
        public static LinkedList<ResourceType> resourcePool = PreSchedule.createResourcePool();

        //********this is wrong
        /// <summary>
        /// create a resource pool for the particular job considering their availability
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static LinkedList<ResourceType> resourcePoolForJob(Job job)
        {
            LinkedList<ResourceType> resourcePoolForJob = new LinkedList<ResourceType>();

            foreach (ResourceForJob node in job.requiredResources)
            {
                resourcePoolForJob.AddLast(node.resourceType);
            }

            foreach (ResourceType node in resourcePoolForJob)
            {
                foreach (ResourceType node2 in resourcePool)
                {
                    if (node.typeName == node2.typeName)
                    {
                        foreach(Resource resource in node2.resources )
                        {
                            if(resource.isAvailable(job.EPST, job.duration))
                            {
                                node.resources.AddLast(resource);
                            }
                        }
                        break;
                    }
                }
            }

            return resourcePoolForJob;
        }



        public static Job scheduleJob(Job job)
        {
            LinkedList<ResourceType> pool = resourcePoolForJob(job);
            
            foreach (ResourceForJob node in job.requiredResources)
            {

            }

            return job;
        }




    }
}
