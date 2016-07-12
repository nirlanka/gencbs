using System;
using System.Collections;
using System.Collections.Generic;
using gencbs.Resources;

namespace gencbs
{
	public class Test
	{
		public Test ()
		{
		}

		public static void createSimpleTestData () 
		{
			//creating dates
			DateTime date1 = new DateTime(2016, 5, 3 , 16,0,0);
			DateTime date2 = new DateTime(2016, 5, 5, 8,0,0);

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
			LinkedList<TimeSlot> bookedTimes = new LinkedList<TimeSlot>();
			bookedTimes.AddLast(new TimeSlot(date1,date2));
			bookedTimes.AddLast(new TimeSlot(date2.AddHours(5) , date2.AddHours(8)));

			//creating a resource type
			ResourceType docTypeA = new ResourceType("surgeon-A");
			ResourceType docTypeB = new ResourceType("surgeon-B");

			// attach stuff
			Resource r1 = new Resource("doctor1", docTypeA, 100, 500);// { type = new ResourceType() { name = "type1" }, efficiency = 100 };
			r1.BookedTime = bookedTimes;
			r1.roster = roster1;
			Resource r2 = new Resource("doctor2", docTypeB, 80, 400);
			r2.BookedTime = bookedTimes;
			r2.roster = roster1;
			r1.updateAvailabilityList();
			docTypeA.resources.AddLast (r1);
			docTypeB.resources.AddLast (r2);

			Data.Init ();

			// add to hashtables
			Data.addResourceType (docTypeA);
			Data.addResourceType (docTypeB);
			Data.addResource (r1);
			Data.addResource (r2);

			// save as files
			Data.Sync ();
		}
	}
}

