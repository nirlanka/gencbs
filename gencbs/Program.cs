using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace gencbs
{
    class Program
    {
        static void Main(string[] args)
        {
//			Test.createSimpleTestData ();

            //Data.Init ();
            //Data.Restore ();
            gencbs.Jobs.Job job1 = new Jobs.Job();
            job1.addRequiredResource(new ResourceType("doc_general_physician", 0));
            job1.addRequiredResource(new ResourceType("doc_anesthesiologist", 0));
            job1.EPST = DateTime.Now.AddDays(10);
            job1.dueDate = DateTime.Now.AddDays(20);
            job1.duration = new TimeSpan(5,0,0);
            job1.delayPanaltyForHour = 10000;

            gencbs.Scheduler.Genetic.GeneticSchedular gs = new Scheduler.Genetic.GeneticSchedular();
            gs.runSchedular(job1);
            

            Console.Read();
        }
    }
}
