using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using gencbs.Resources;

namespace gencbs.Jobs
{
    class Job : IComparable<Job>
    {
        private static int nextId= 0;
        public DateTime EPST{ get; set;} //Earliest Possible Start time
        public DateTime dueDate { get; set; }
        public TimeSpan duration { get; set; }
        public int delayPanaltyForHour { get; set; }
        public int jobID{ get; set;}

        public Double fitness { get; set; }

        public String jobName { get; set; }
        public LinkedList<ResourceForJob> requiredResources { get; set; }

        public int cost {get; set;}


        public Job()
        {
            Interlocked.Increment(ref nextId);
            this.jobID = nextId;
            this.requiredResources = new LinkedList<ResourceForJob>();
        }

        public void addRequiredResource(ResourceType type)
        {
            ResourceForJob reqResource = new ResourceForJob(type);
            this.requiredResources.AddLast(reqResource);
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

        public Job cross(Job job, int breakPoint)
        {
            return null;
        }

        //we have to consider the efficiency of the resources when gettig the intersection
        private LinkedList<TimeSlot> getIntersection()
        {
            LinkedListNode<ResourceForJob> node = this.requiredResources.First;
            LinkedList<TimeSlot> result = node.Value.allocated_resource.intersectAvailabilityList(node.Next.Value.allocated_resource.availability);
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
            LinkedList<TimeSlot> intersectionOfTimes = this.getIntersection();

            //get the least posible starting time of the job
            foreach (TimeSlot slot in intersectionOfTimes)
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
            if (cost == 0) return 1; //to avoid devision by zero
            return cost;
        }


        public int CompareTo(Job job)
        {
            return this.fitness.CompareTo(job.fitness);
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
