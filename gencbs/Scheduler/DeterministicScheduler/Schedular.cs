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

        //********this is wrong
        /// <summary>
        /// create a resource pool for the particular job considering their availability
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static LinkedList<ResourcePoolNode> resourcePoolForJob(Job job)
        {
            LinkedList<ResourcePoolNode> resourcePoolForJob = new LinkedList<ResourcePoolNode>();

            foreach (ResourceForJob node in job.requiredResources)
            {
                resourcePoolForJob.AddLast(new ResourcePoolNode(node.resourceType));
            }

            foreach(ResourcePoolNode node in resourcePoolForJob )
            {
                foreach (ResourcePoolNode node2 in resourcePool)
                {
                    if (node.type.typeName == node2.type.typeName)
                    {
                        foreach(Resource resource in node2.resourceList )
                        {
                            if(resource.isAvailable(job.EPST, job.duration))
                            {
                                node.resourceList.AddLast(resource);
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
            LinkedList<ResourcePoolNode> pool = resourcePoolForJob(job);
            
            foreach (ResourceForJob node in job.requiredResources)
            {

            }

            return job;
        }




    }
}
