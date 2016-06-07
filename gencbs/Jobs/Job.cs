using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using gencbs.Resources;

namespace gencbs.Jobs
{
    class Job
    {
        private static int nextId= 0;
        public DateTime EPST{ get; set;} //Earliest Possible Start time
        public DateTime dueDate { get; set; }
        public TimeSpan duration { get; set; }
        public int delayPanaltyForHour { get; set; }
        public int jobID{ get; set;}

        public String jobName { get; set; }
        public LinkedList<ResourceForJob> requiredResources { get; set; }

        public int cost {get; set;}


        public Job()
        {
            Interlocked.Increment(ref nextId);
            this.jobID = nextId;
        }

        public Job(Job job)
        {
            EPST = job.EPST;
            dueDate = job.dueDate;
            duration = job.duration;
            jobID = job.jobID;
            jobName = job.jobName;
            delayPanaltyForHour = job.delayPanaltyForHour;
            requiredResources = job.requiredResources;
        }

        //create a resource pool for the job
        public LinkedList<LinkedList<Resources.Resource>> createResourcePool()
        {
            return null;
        }

        //we have to consider the efficiency of the resources when gettig the intersection
        private LinkedList<timeSlot> getIntersection()
        {
            LinkedListNode<ResourceForJob> node = this.requiredResources.First;
            LinkedList<timeSlot> result = node.Value.allocated_resource.intersectAvailabilityList(node.Next.Value.allocated_resource.availability);
            node = node.Next;
            while (node.Next != null)
            {
                result = node.Value.allocated_resource.intersectAvailabilityList(result);
            }
            return result;
            
        }

        /// <summary>
        /// calculate the cost added by delaying the job from the due date
        /// </summary>
        /// <returns></returns>
        private int calculateDelayPanalty()
        {
            LinkedList<timeSlot> intersectionOfTimes = this.getIntersection();

            //get the least posible starting time of the job
            foreach (timeSlot slot in intersectionOfTimes)
            {
                if (slot.TimeSpan >= this.duration)
                {
                    if (slot.startTime > this.EPST)
                    {
                        TimeSpan delay = slot.startTime - this.EPST;
                        return delay.Hours * this.delayPanaltyForHour;
                    }
                    else return 0;
                }
            }

            return 0;
        }

        /// <summary>
        /// get the total cost of the job
        /// </summary>
        /// <returns></returns>
        public int getCost()
        {
            int cost = 0;
            foreach (ResourceForJob res in this.requiredResources)
            {
                cost += res.allocated_resource.getCost(this.duration);
            }

            cost += calculateDelayPanalty();

            return cost;
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
