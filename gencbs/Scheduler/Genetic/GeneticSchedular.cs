using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;
using gencbs.Jobs;

namespace gencbs.Scheduler.Genetic
{
    class GeneticSchedular
    {
        static int populationSize = 20;

        public Job[] population = new Job[populationSize];

        public LinkedList<ResourcePoolNode> resourcePool = PreSchedule.createResourcePool();

        /// <summary>
        /// create the initial population by randomly assigning resources to the job
        /// </summary>
        /// <param name="job"></param>
        public void createInitialGeneration(Job job)
        {
            for (int i = 0; i < populationSize; i++)
            {
                population[i] = new Job(job);
                assignRandomResources(population[i]);
            }
        }

        /// <summary>
        /// get a random resource of the given type from the resource pool
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Resource getRandomResource(ResourceType type)
        {
            foreach (ResourcePoolNode node in resourcePool)
            {
                if (node.type == type)
                {
                    return node.getRandomResource();
                }
            }
            return null;
        }

        /// <summary>
        /// create a job with randomly assign resources
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public Job assignRandomResources(Job job)
        {
            foreach(ResourceForJob res in job.requiredResources) 
            {
                res.allocated_resource = getRandomResource(res.resourceType);
            }

            return job;
        }


        /// <summary>
        /// do cross overs to the population
        /// </summary>
        public void crossover(Resource resource1 , Resource resource2)
        {

        }

        public void runSchedular(Job job)
        {
            createInitialGeneration(job);
        }
    }
}
