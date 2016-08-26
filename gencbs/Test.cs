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
            //testing data
            //resource types
            //doctors
            ResourceType doc_genral_physician = new ResourceType("doc_general_physician", 0); //A doctor who offers treatment for mild conditions.
            ResourceType doc_anesthesiologist = new ResourceType("doc_anesthesiologist", 0); //Administers and studies anesthesia for surgical procedures
            ResourceType doc_general_surgeons = new ResourceType("doc_general_surgeons", 0); //Performs surgeries that are related to different areas of medicine
            ResourceType doc_pediatric_cardiologist = new ResourceType("doc_pediatric_cardiologist", 0); //Treats and diagnoses heart complication in infants.
            ResourceType doc_urologist = new ResourceType("doc_urologist", 0); //Treats, diagnoses and studies health issues related to the urinary tract, kidney and urinary system
            ResourceType doc_andrologist = new ResourceType("doc_andrologist", 0); //Treats and diagnoses medical issues with the male reproductive system
            ResourceType doc_gynecologist = new ResourceType("doc_gynecologist", 0); //Treats and diagnoses conditions in the reproductive system of females
            ResourceType doc_radiation_oncologist = new ResourceType("doc_andrologist", 0); //Specializes in treating cancer using radiation
            ResourceType doc_surgical_oncologist = new ResourceType("doc_surgical_oncologist", 0); //Deals with administering surgical procedures to treat cancer. Uses biopsy to diagnose cancer. Removes tumors and cancerous tissues
            ResourceType doc_neurosurgeon = new ResourceType("doc_neurosurgeon", 0); //Specializes in the treatment of diseases affecting the nervous system and the brain


            //nurses
            ResourceType nurse_general = new ResourceType("nurse_general", 0);
            ResourceType nurse_perioperative = new ResourceType("nurse_perioperative", 0); //operating room nurses
            ResourceType nurse_anesthetists = new ResourceType("nurse_anesthetists", 0);
            ResourceType nurse_midwife = new ResourceType("nurse_midwife", 0); //specialized in childbirth
            ResourceType nurse_oncology = new ResourceType("nurse_oncology", 0); //specialized in cancer treatments

            //allied health proffesionals
            ResourceType ahs_surgical_technologist = new ResourceType("ahs_surgical_technologist", 0); //part of a surgical team
            ResourceType ahs_radiotherapist = new ResourceType("ahs_radiotherapist", 0); //works in radiation therapy
            ResourceType ahs_radiation_scientist = new ResourceType("ahs_radiation_scientist", 0);

            //other hospital staff.
            //todo: add other hospital staff here
            //----------------------------------------------------------------
            
            //machines
            //todo: add some machine types here
            ResourceType mach_MRI_scanner = new ResourceType("mach_MRI_scanner", 1000);
            ResourceType mach_XRay_scanner = new ResourceType("mach_XRay_scanner", 1000);
            ResourceType mach_medical_ventilator = new ResourceType("mach_medical_ventilator", 1000);
            ResourceType mach_anesthetic_machine = new ResourceType("mach_anesthetic_machine", 1000);
            ResourceType mach_heart_lung_machine = new ResourceType("mach_heart_lung_machine", 1000);
            ResourceType mach_ECLS = new ResourceType("mach_ECLS", 1000);//extracorporeal life support (ECLS)
            ResourceType mach_dialysis = new ResourceType("mach_dialysis", 1000);
            ResourceType mach_ultrasound_scanner = new ResourceType("mach_ultrasound_scanner", 1000);
            ResourceType anesthesia_machine = new ResourceType("anesthesia_machine", 1000);
            


            //rosters
            //--todo: add set of different rosteres here
            //general week days
            //These rosters are week base
            DateTime monday = new DateTime(2016, 5, 23, 0, 0, 0); //monday 12.00AM
            DateTime tuesday = new DateTime(2016, 5, 24, 0, 0, 0);
            DateTime wednesday = new DateTime(2016, 5, 25, 0, 0, 0);
            DateTime thursday = new DateTime(2016, 5, 26, 0, 0, 0);
            DateTime friday = new DateTime(2016, 5, 27, 0, 0, 0);
            DateTime saturday = new DateTime(2016, 5, 28, 0, 0, 0);
            DateTime sunday = new DateTime(2016, 5, 29, 0, 0, 0);


            LinkedList<CalenderSlot> roster_A = new LinkedList<CalenderSlot>();
            roster_A.AddLast(new CalenderSlot(sunday, sunday.AddHours(8))); //12-8
            roster_A.AddLast(new CalenderSlot(monday, monday.AddHours(16)));//8-4
            roster_A.AddLast(new CalenderSlot(tuesday.AddHours(16), wednesday));//4-12
            roster_A.AddLast(new CalenderSlot(thursday, thursday.AddHours(8)));
            roster_A.AddLast(new CalenderSlot(friday.AddHours(16), saturday));
            roster_A.AddLast(new CalenderSlot(saturday.AddHours(8), saturday.AddHours(4)));

            LinkedList<CalenderSlot> roster_B = new LinkedList<CalenderSlot>();
            roster_B.AddLast(new CalenderSlot(sunday.AddHours(8), sunday.AddHours(16))); //12-8
            roster_B.AddLast(new CalenderSlot(monday.AddHours(16), tuesday));//8-4
            roster_B.AddLast(new CalenderSlot(tuesday.AddHours(8), tuesday.AddHours(16)));//4-12
            roster_B.AddLast(new CalenderSlot(wednesday, wednesday.AddHours(16)));
            roster_B.AddLast(new CalenderSlot(thursday.AddHours(16), friday));
            roster_B.AddLast(new CalenderSlot(saturday, saturday.AddHours(8)));

            LinkedList<CalenderSlot> roster_C = new LinkedList<CalenderSlot>();
            roster_C.AddLast(new CalenderSlot(sunday.AddHours(16), monday)); //12-8
            roster_C.AddLast(new CalenderSlot(tuesday, tuesday.AddHours(8)));//8-4
            roster_C.AddLast(new CalenderSlot(wednesday.AddHours(16), thursday));//4-12
            roster_C.AddLast(new CalenderSlot(thursday.AddHours(8), thursday.AddHours(16)));
            roster_C.AddLast(new CalenderSlot(friday, friday.AddHours(16)));
            roster_C.AddLast(new CalenderSlot(saturday.AddHours(16), sunday));

            //roster for machines, full time machines
            LinkedList<CalenderSlot> roster_Machine_fullTime = new LinkedList<CalenderSlot>();
            roster_Machine_fullTime.AddLast(new CalenderSlot(sunday, saturday.AddHours(24))); 

            //add some more rosters if needed
            //-----> add at least 3 resources from each catogory


            //--------------------------------------------now create some resources. few are created, Waruna
            //---RESOURCES--
            //DOCTORS
            //todo: add doctors here
            //general surgens
            Resource doc_001 = new Labour("doc_001", doc_general_surgeons, 80, 1000);
            Resource doc_002 = new Labour("doc_002", doc_general_surgeons, 90, 1200);
            Resource doc_003 = new Labour("doc_003", doc_general_surgeons, 70,800);
            Resource doc_004 = new Labour("doc_004", doc_general_surgeons, 50, 600);
            Resource doc_005 = new Labour("doc_005", doc_general_surgeons, 85 , 900);

            //doc_anesthesiologist
            Resource doc_006 = new Labour("doc_006", doc_anesthesiologist, 80, 1500);
            Resource doc_007 = new Labour("doc_007", doc_anesthesiologist, 80, 1100);
            Resource doc_008 = new Labour("doc_008", doc_anesthesiologist, 90, 1000);

            //NURSES
            //todo: add nurses here
            Resource nrsgen_001 = new Labour("nrsgen_001", nurse_general, 80, 300);
            Resource nrsgen_002 = new Labour("nrsgen_002", nurse_general, 70, 300);
            Resource nrsgen_003 = new Labour("nrsgen_003", nurse_general, 80, 300);
            Resource nrsgen_004 = new Labour("nrsgen_004", nurse_general, 80, 300);
            Resource nrsgen_005 = new Labour("nrsgen_005", nurse_general, 80, 300);

            Resource nrsper_001 = new Labour("nrsper_001", nurse_perioperative, 80, 350);
            Resource nrsper_002 = new Labour("nrsper_002", nurse_perioperative, 75, 350);
            Resource nrsper_003 = new Labour("nrsper_003", nurse_perioperative, 90, 350);
            Resource nrsper_004 = new Labour("nrsper_004", nurse_perioperative, 90, 350);
            Resource nrsper_005 = new Labour("nrsper_005", nurse_perioperative, 86, 350);

            Resource nrsmid_001 = new Labour("nrsmid_001", nurse_midwife, 74, 250);
            Resource nrsmid_002 = new Labour("nrsmid_002", nurse_midwife, 74, 300);
            Resource nrsmid_003 = new Labour("nrsmid_003", nurse_midwife, 74, 250);
            Resource nrsmid_004 = new Labour("nrsmid_004", nurse_midwife, 74, 250);
            Resource nrsmid_005 = new Labour("nrsmid_005", nurse_midwife, 74, 300);

            Resource nrsane_001 = new Labour("nrsane_001", nurse_anesthetists, 83, 350);
            Resource nrsane_002 = new Labour("nrsane_002", nurse_anesthetists, 90, 300);
            Resource nrsane_003 = new Labour("nrsane_003", nurse_anesthetists, 88, 300);
            Resource nrsane_004 = new Labour("nrsane_004", nurse_anesthetists, 75, 300);
            Resource nrsane_005 = new Labour("nrsane_005", nurse_anesthetists, 92, 300);

            Resource nrsonc_001 = new Labour("nrconc_001", nurse_oncology, 79, 300);
            Resource nrsonc_002 = new Labour("nrconc_002", nurse_oncology, 89, 300);
            Resource nrsonc_003 = new Labour("nrconc_003", nurse_oncology, 85, 300);
            Resource nrsonc_004 = new Labour("nrconc_004", nurse_oncology, 75, 300);
            Resource nrsonc_005 = new Labour("nrconc_005", nurse_oncology, 78, 300);



			//creating dates
			DateTime date1 = new DateTime(2016, 5, 3 , 16,0,0);
			DateTime date2 = new DateTime(2016, 5, 5, 8,0,0);

			


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
			r1.roster = roster_A;
			Resource r2 = new Resource("doctor2", docTypeB, 80, 400);
			r2.BookedTime = bookedTimes;
			r2.roster = roster_A;
			r1.updateAvailabilityList();
			docTypeA.resources.AddLast (r1);
			docTypeB.resources.AddLast (r2);

			Data.Init ();

			// add to hashtables
			Data.addResourceType (docTypeA);
			Data.addResourceType (docTypeB);
			Data.addResource (r1);
			Data.addResource (r2);
            Data.addResource(doc_001);
            Data.addResource(doc_002);
            Data.addResource(doc_003);
            Data.addResource(doc_004);
            Data.addResource(doc_005);
            Data.addResource(doc_006);
            Data.addResource(doc_007);
            Data.addResource(doc_008);

			// save as files
			Data.Sync ();
		}
	}
}

