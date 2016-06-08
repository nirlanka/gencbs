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
        static int crossoverLimit = 16; // number of individuals to crossover, other set will be mutate
        public Job[] population = new Job[populationSize];
        public Job[] nextGeneration = new Job[populationSize];
        private Random randomNumber = new Random();


        public LinkedList<ResourcePoolNode> resourcePool = PreSchedule.createResourcePool();

        /// <summary>
        /// create the initial population by randomly assigning resources to jobs
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
        /// randomly assign resources to a job
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

        private void crossoverPopulation()
        {
            int[] selection; 
            Job[] newJobs = new Job[2];
            for (int i = 0; i < crossoverLimit / 2; i++)
            {
                selection = selectParentIndex();
                newJobs = crossover(population[selection[1]], population[selection[1]]);
                this.nextGeneration[2*i] = new Job(newJobs[0]);
                this.nextGeneration[2 * i + 1] = new Job(newJobs[1]);
            }
        }

        /// <summary>
        /// cross over two individuals to generate two offsprings
        /// </summary>
        public Job[] crossover(Job job1, Job job2)
        {
            Job[] offsprings = new Job[2];

            int breakPoint = randomNumber.Next(job1.requiredResources.Count);

            offsprings[0] = new Job(job1);
            offsprings[1] = new Job(job1);

            for (int i = 0; i < job1.requiredResources.Count; i++)
            {
                if (i < breakPoint)
                {
                    offsprings[0].requiredResources.ElementAt(i).allocated_resource = job2.requiredResources.ElementAt(i).allocated_resource;
                }
                else
                {
                    offsprings[1].requiredResources.ElementAt(i).allocated_resource = job2.requiredResources.ElementAt(i).allocated_resource;
                }
            }

            return offsprings;
        }

        /// <summary>
        /// select two parents from the initial population for crossovers, 
        /// fitness of the individuals are considered for selection
        /// </summary>
        /// <returns></returns>
        private int[] selectParentIndex()
        {

            //here only random numbers are selected,but probabilistic aproach has to be taken
            int[] selectedIndex = new int[2];
            selectedIndex[0] = randomNumber.Next(crossoverLimit - 1);
            selectedIndex[1] = randomNumber.Next(crossoverLimit - 1);
            while (selectedIndex[0] != selectedIndex[1])
            {
                selectedIndex[1] = randomNumber.Next(crossoverLimit - 1);
            }

            return selectedIndex;
        }

        /// <summary>
        /// calculate the fitness function of each job and sort the population accordingly
        /// </summary>
        private void sortPopulationByFitness()
        {
            Double totalFitness = 0;
            for (int i = 0; i < populationSize; i++)
            {
                population[i].cost = population[i].getCost();
                population[i].fitness = 1/population[i].cost;
                totalFitness += population[i].fitness;
            }

            for (int i = 0; i < populationSize; i++)
            {
               // population[i].fitness = 1 - ( population[i].cost / totalCost);
                population[i].fitness = population[i].fitness / totalFitness;
            }

            Array.Sort(population);

        }

        public void runSchedular(Job job)
        {
            createInitialGeneration(job);
        }
    }
}
