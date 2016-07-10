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
//			//creating dates
//            DateTime date1 = new DateTime(2016, 5, 3 , 16,0,0);
//            DateTime date2 = new DateTime(2016, 5, 5, 8,0,0);
//
//            //creating a roster
//            LinkedList<CalenderSlot> roster1 = new LinkedList<CalenderSlot>();
//            DateTime monday = new DateTime(2016, 5, 23, 0, 0, 0); //monday 12.00AM
//            DateTime tuesday = new DateTime(2016, 5, 24, 0, 0, 0);
//            DateTime wednesday = new DateTime(2016, 5, 25, 0, 0, 0);
//            DateTime thursday = new DateTime(2016, 5, 26, 0, 0, 0);
//            DateTime friday = new DateTime(2016, 5, 27, 0, 0, 0);
//            DateTime saturday = new DateTime(2016, 5, 28, 0, 0, 0);
//            DateTime sunday = new DateTime(2016, 5, 29, 0, 0, 0);
//
//            roster1.AddLast(new CalenderSlot(monday, monday.AddHours(8)));
//            roster1.AddLast(new CalenderSlot(monday.AddHours(16), tuesday));
//            roster1.AddLast(new CalenderSlot(thursday.AddHours(8), friday.AddHours(8)));
//
//
//            //creating booked time list
//            LinkedList<TimeSlot> bookedTimes = new LinkedList<TimeSlot>();
//            bookedTimes.AddLast(new TimeSlot(date1,date2));
//            bookedTimes.AddLast(new TimeSlot(date2.AddHours(5) , date2.AddHours(8)));
//
//            //creating a resource type
//            ResourceType doctorType_A = new ResourceType("doctorType_A");
//
//            Resource r1 = new Resource("doctor1", doctorType_A, 100, 500);// { type = new ResourceType() { name = "type1" }, efficiency = 100 };
//            r1.BookedTime = bookedTimes;
//            r1.roster = roster1;
//            Resource r2 = new Resource("doctor2", doctorType_A, 80, 400);
//            r2.BookedTime = bookedTimes;
//            r2.roster = roster1;
//            r1.updateAvailabilityList();


			Data.Init ();

//			Data.addLabour (r1);
//			Data.addLabour (r2);

//			Data.Sync ();
			Data.Restore ();


            Console.Read();
        }
    }
}
