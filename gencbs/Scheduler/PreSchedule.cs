using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;
using System.IO;
using Newtonsoft.Json;

namespace gencbs.Scheduler
{
    class PreSchedule
    {
        private static String dataDirectory = @"C:\Users\waruna\Desktop\gencbs\gencbs\test\data";
        public PreSchedule()
        {

        }

        /// <summary>
        /// get all the resource types stored as json files
        /// </summary>
        /// <returns></returns>
        public static LinkedList<ResourceType> getResourceTypes()
        {
            LinkedList<ResourceType> typeList = new LinkedList<ResourceType>();
            String typeDirectory = dataDirectory + @"\ResourceTypes";
            String jsonString;
            foreach (String type in Directory.GetFiles(typeDirectory))
            {
                jsonString = File.ReadAllText(type);
                ResourceType temp = JsonConvert.DeserializeObject<ResourceType>(jsonString);
                typeList.AddLast(temp);
            }

            return typeList;
        }

        /// <summary>
        /// extract all the resources stored as json files
        /// </summary>
        /// <returns></returns>
        public static LinkedList<Resource> getResourcesList()
        {
            LinkedList<Resource> resourceList = new LinkedList<Resource>();
            String resourcesDirectory = dataDirectory + @"\Resources\";
            String[] subDirectories = {"Labour" , "Machines" , "Tools" };
            String jsonString;
            foreach (String sub in subDirectories)
            {
                foreach (String type in Directory.GetFiles(resourcesDirectory + sub))
                {
                    jsonString = File.ReadAllText(type);
                    Resource temp = JsonConvert.DeserializeObject<Resource>(jsonString);
                    resourceList.AddLast(temp);
                }
            }

            return resourceList;
        }

        /// <summary>
        /// creating the resource pool with all the availble resources catagorized according to the types.
        /// </summary>
        /// <returns></returns>
        public static LinkedList<ResourceType> createResourcePool()
        {
            LinkedList<ResourceType> resourcePool = getResourceTypes();

            

            LinkedList<Resource> resourceList = getResourcesList();

            foreach (Resource resource in getResourcesList())
            {
                foreach (ResourceType node in resourcePool)
                {
                    if (node.typeName == resource.type.typeName)
                    {
                        node.resources.AddLast(resource);
                        break;
                    }
                }
            }

            return resourcePool;
        }
    }
}
