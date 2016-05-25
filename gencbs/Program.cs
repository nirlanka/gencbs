using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace gencbs
{
    class Program
    {
        static void Main(string[] args)
        {
            //ResourceType Doc = new ResourceType( "Doctor");
            //ResourceType Doc2 = new ResourceType("Doctr");
            //Resource Doctor1 = new Resource(Doc,100);
            DateTime date1 = new DateTime(2016, 5, 3 , 16,0,0);
            DateTime date2 = new DateTime(2016, 5, 5, 8,0,0);

            //CalenderSlot ros = new CalenderSlot(date1, date2);


            //DateTime date3 = new DateTime(2016, 5, 15, 17, 0, 0);
            //DateTime date4 = new DateTime(2016, 5, 16, 9, 0, 0);

            //timeSlot job = new timeSlot(date3, date4);
            ////Resource machine1 = new Machine();
            ////Resource machine2 = new Machine();
            ////Console.WriteLine(date1.TimeOfDay - date2.TimeOfDay);
            //int gap = date1.DayOfWeek - date2.DayOfWeek;
            //Console.WriteLine("roster - " + ros);
            //Console.WriteLine("free- " + job);
            //Console.WriteLine("availble -" + ros.intersect(job));

            //creating booked time list,roster
            LinkedList<timeSlot> roster1 = new LinkedList<timeSlot>();
            roster1.AddLast(new timeSlot(date1,date2));
            roster1.AddLast(new timeSlot(date2.AddHours(5) , date2.AddHours(8)));

            //creating a resource type
            ResourceType doctorType_A = new ResourceType("doctorType_A");

            Resource r1 = new Resource("doctor1", doctorType_A, 100);// { type = new ResourceType() { name = "type1" }, efficiency = 100 };
            r1.BookedTime = roster1;
            Resource r2 = new Resource("doctor2", doctorType_A, 80);
            r2.BookedTime = roster1;

            LinkedList<Resource> resourceList = new LinkedList<Resource>();
            resourceList.AddLast(r1);
            resourceList.AddLast(r2);


            JsonSerializer serializer = new JsonSerializer();


            foreach (Resource resource in resourceList)
            {
                using (StreamWriter file = File.CreateText(@"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Resources\Labours\" + resource.name + ".json"))
                using (JsonWriter jsonWriter = new JsonTextWriter(file))
                {
                    serializer.Serialize(jsonWriter, resource);
                    if(resource.Equals(resourceList.Last))
                    {
                        file.Close();
                    }
                    
                }
            }
            

            String jsonString = File.ReadAllText(@"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Resources\Labours\doc2.json");
            Console.WriteLine(jsonString);

            //deserializing the json file into a Resource object
            Resource deserializedResource = JsonConvert.DeserializeObject<Resource>(jsonString);

            Console.Read();
        }
    }
}
