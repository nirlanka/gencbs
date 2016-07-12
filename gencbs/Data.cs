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
//		public static string RESOURCES_DIR = "/home/nir/Desktop/data/proj/gencbs/gencbs/test/data";
		public static string RESOURCES_DIR = "/home/nir/Desktop/data/proj/gencbs/gencbs/test/data";
//		public string RESOURCES_DIR = "C:\Users\waruna\Desktop\gencbs\gencbs\test\data";
			
		public static Hashtable Rosters;
		public static Hashtable AllResources;
		public static Hashtable ResTypes;

		public static void Init ()
		{
			Rosters = new Hashtable ();
			AllResources = new Hashtable ();
			ResTypes = new Hashtable ();
		}


		public static void Restore ()
		{
			String jsonString;

			String[] resourceTypeFiles = Directory.GetFiles (Path.Combine (RESOURCES_DIR, "ResourceTypes"));
			foreach (string _restype in resourceTypeFiles)
			{
				jsonString = File.ReadAllText (_restype);
				ResourceType restype = JsonConvert.DeserializeObject<ResourceType> (jsonString);
				restype.resources = new LinkedList<Resource> ();
				if (restype._resources == null)
					restype._resources = new LinkedList<string> ();
				restype.RestoreFromSerialization (); // includes loading resources
				Data.addResourceType (restype);
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
			foreach (string _res in AllResources.Keys)
			{
				Resource res = (Resource) (AllResources [_res]);
//				if (res._roster == null) {
//					addRoster (res.name, res.roster);
//				}
				res.PrepareForSerialization ();

				using (StreamWriter file = File.CreateText(Path.Combine(RESOURCES_DIR, "Resources", res.name+".json")))
				using (JsonWriter jsonWriter = new JsonTextWriter(file))
				{
					serializer.Serialize (jsonWriter, res);
				}
			}

			foreach (var _r in ResTypes.Keys) {
				var r = getResourceType ((string)_r);
				r.PrepareForSerialization ();

				using (StreamWriter file = File.CreateText(Path.Combine(RESOURCES_DIR, "ResourceTypes", r.typeName+".json")))
				using (JsonWriter jsonWriter = new JsonTextWriter(file))
				{
					serializer.Serialize (jsonWriter, r);
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
		}


		public static LinkedList<CalenderSlot> getRoster (string key)
		{
			return (LinkedList<CalenderSlot>) Rosters [key];
		}
		public static void addRoster (string key, LinkedList<CalenderSlot> roster)
		{
			Console.WriteLine ("roster");//debug
			Rosters.Add (key, roster);
		}

		public static ResourceType getResourceType (string key)
		{
			return (ResourceType) ResTypes [key];
		}
		public static void addResourceType (ResourceType res)
		{
			Console.WriteLine (res.typeName);//debug
			ResTypes.Add (res.typeName, res);
		}

		public static Resource getResource (string key)
		{
			return (Resource) AllResources [key];
		}
		public static void addResource (Resource res)
		{
			Console.WriteLine (res.name);//debug
			AllResources.Add (res.name, res);
		}
		public static Resource readResource (string name)
		{
			Console.WriteLine ("reading "+name);//debug
			var jsonString = File.ReadAllText (Path.Combine (RESOURCES_DIR, "Resources", name+".json"));
			return JsonConvert.DeserializeObject<Resource> (jsonString);
		}
			
	}
}

