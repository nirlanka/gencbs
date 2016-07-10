using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using gencbs.Resources;
using Newtonsoft.Json;

namespace gencbs
{
	public class Data
	{
		public Data ()
		{
		}

		// TODO: Read this from App.config
		public static string RESOURCES_DIR = "/home/nir/Desktop/data/proj/gencbs/gencbs/test/data";
//		public string RESOURCES_DIR = "C:\Users\waruna\Desktop\gencbs\gencbs\test\data";
			
		public static Hashtable Rosters;
		public static Hashtable Labourers;
//		public static Hashtable BookedTimes;

		public static void Init ()
		{
			Rosters = new Hashtable ();
			Labourers = new Hashtable ();
//			BookedTimes = new Hashtable ();
		}


		public static void Restore ()
		{
			String jsonString;
			String[] labourerFiles = Directory.GetFiles(Path.Combine(RESOURCES_DIR, "Resources", "Labours"));
			foreach (string labourer in labourerFiles)
			{
				jsonString = File.ReadAllText (labourer);
				Resource res = JsonConvert.DeserializeObject<Resource> (jsonString);
				res.RestoreFromSerialization ();
				Data.addLabour (res);
			}

			String[] rosterFiles = Directory.GetFiles(Path.Combine(RESOURCES_DIR, "Calenders"));
			foreach (string roster in rosterFiles)
			{
				jsonString = File.ReadAllText (roster);
				LinkedList<CalenderSlot> cal = JsonConvert.DeserializeObject<LinkedList<CalenderSlot>> (jsonString);
				Data.addRoster (roster, cal);
			}
		}

		public static void Sync ()
		{
			JsonSerializer serializer = new JsonSerializer();

			// Save labourers
			foreach (string _res in Labourers.Keys)
			{
				Resource res = (Resource) (Labourers [_res]);
//				if (res._roster == null) {
//					addRoster (res.name, res.roster);
//				}
				res.PrepareForSerialization ();

				using (StreamWriter file = File.CreateText(Path.Combine(RESOURCES_DIR, "Resources", "Labours", res.name+".json")))
				using (JsonWriter jsonWriter = new JsonTextWriter(file))
				{
					serializer.Serialize (jsonWriter, res);
				}
			}

			// Save calenders
			foreach (string _cal in Rosters.Keys)
			{
				var cal = (LinkedList<CalenderSlot>) (Rosters [_cal]);
				using (StreamWriter file = File.CreateText (Path.Combine(RESOURCES_DIR, "Calenders", _cal+".json")))
				using (JsonWriter jsonWriter = new JsonTextWriter(file))
				{
					serializer.Serialize (jsonWriter, cal);
					file.Close ();
				}
			}

			// Save booked times
//			foreach (var _bookedTimes in BookedTimes.Keys) 
//			{
//				LinkedList<timeSlot> bookedTimes = BookedTimes [_bookedTimes];
//				using (StreamWriter file = File.CreateText (Path.Combine(RESOURCES_DIR, "Calenders", _bookedTimes+".json")))
//				using (JsonWriter jsonWriter = new JsonTextWriter(file))
//				{
//					serializer.Serialize (jsonWriter, bookedTimes);
//					file.Close ();
//				}
//			}
		}


		public static LinkedList<CalenderSlot> getRoster (string key)
		{
			return (LinkedList<CalenderSlot>) Rosters [key];
		}
		public static void addRoster (string key, LinkedList<CalenderSlot> roster)
		{
			Rosters.Add (key, roster);
		}
			
		public static Resource getLabour (string key)
		{
			return (Resource) Labourers [key];
		}
		public static void addLabour (Resource res)
		{
			Labourers.Add (res.name, res);
		}

//		public static LinkedList<timeSlot> getBookedTime (string key)
//		{
//			return (LinkedList<timeSlot>) BookedTimes [key];
//		}
//		public static void addBookedTime (string key, LinkedList<timeSlot> bookedTimes)
//		{
//			BookedTimes.Add (key, bookedTimes);
//		}
	}
}

