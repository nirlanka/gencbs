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

            //creating a roster
            LinkedList<CalenderSlot> roster1 = new LinkedList<CalenderSlot>();
            DateTime monday = new DateTime(2016, 5, 23, 0, 0, 0); //monday 12.00AM
            DateTime tuesday = new DateTime(2016, 5, 24, 0, 0, 0);
            DateTime wednesday = new DateTime(2016, 5, 25, 0, 0, 0);
            DateTime thursday = new DateTime(2016, 5, 26, 0, 0, 0);
            DateTime friday = new DateTime(2016, 5, 27, 0, 0, 0);
            DateTime saturday = new DateTime(2016, 5, 28, 0, 0, 0);
            DateTime sunday = new DateTime(2016, 5, 29, 0, 0, 0);

            roster1.AddLast(new CalenderSlot(monday, monday.AddHours(8)));
            roster1.AddLast(new CalenderSlot(monday.AddHours(16), tuesday));
            roster1.AddLast(new CalenderSlot(thursday.AddHours(8), friday.AddHours(8)));


            //creating booked time list
            LinkedList<timeSlot> bookedTimes = new LinkedList<timeSlot>();
            bookedTimes.AddLast(new timeSlot(date1,date2));
            bookedTimes.AddLast(new timeSlot(date2.AddHours(5) , date2.AddHours(8)));

            //creating a resource type
            ResourceType doctorType_A = new ResourceType("doctorType_A");

            Resource r1 = new Resource("doctor1", doctorType_A, 100, 500);// { type = new ResourceType() { name = "type1" }, efficiency = 100 };
            r1.BookedTime = bookedTimes;
            r1.roster = roster1;
            Resource r2 = new Resource("doctor2", doctorType_A, 80, 400);
            r2.BookedTime = bookedTimes;
            r2.roster = roster1;
            r1.updateAvailabilityList();

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

            using (StreamWriter file = File.CreateText(@"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Calenders\roster1.json"))
            using (JsonWriter jsonWriter = new JsonTextWriter(file))
            {
                serializer.Serialize(jsonWriter, roster1);
                file.Close();
            }
            

            String jsonString = File.ReadAllText(@"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Resources\Labours\doc2.json");
            //Console.WriteLine(jsonString);

            String directory = @"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Resources\Labours";
            String[] labournames = Directory.GetFiles(directory);

            LinkedList<Resource> labourList = new LinkedList<Resource>();
            foreach (String labour in labournames)
            {
                jsonString = File.ReadAllText(labour);
                Resource temp = JsonConvert.DeserializeObject<Resource>(jsonString);
                labourList.AddLast(temp);
            }

            //foreach (Resource res in labourList)
            //{
            //    Console.WriteLine(res.name);
            //}

            //deserializing the json file into a Resource object
            Resource deserializedResource = JsonConvert.DeserializeObject<Resource>(jsonString);

            Console.Read();
        }
    }
}
