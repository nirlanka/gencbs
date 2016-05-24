using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;
using System.Web.Script.Serialization;
using System.IO;

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

            LinkedList<timeSlot> availability1 = new LinkedList<timeSlot>();
            availability1.AddLast(new timeSlot(date1,date2));
            availability1.AddLast(new timeSlot(date2.AddHours(5) , date2.AddHours(8)));

            Resource r1 = new Resource("doc1", new ResourceType("type1"), 100);// { type = new ResourceType() { name = "type1" }, efficiency = 100 };
            r1.availability = availability1;
            Resource r2 = new Resource("doc2", new ResourceType("type1"), 10); 
            var serializer = new JavaScriptSerializer();
            var result = serializer.Serialize(r1);
            //Console.WriteLine(result);

            //using (StreamWriter file = File.CreateText(@"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Resources\Labours\doc1.json"))
            //{
            //    file.Write(result);
            //    file.Close();
            //}

            String jsonString = File.ReadAllText(@"C:\Users\waruna\Desktop\gencbs\gencbs\test\data\Resources\Labours\doc1.json");
            var doctor = serializer.Deserialize<LinkedList<Resource>>(jsonString);
            Console.WriteLine(doctor.First.Value);

            result = serializer.Serialize(r2);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
