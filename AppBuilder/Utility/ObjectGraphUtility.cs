using AppBuilder.DAL;
using AppBuilder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AppBuilder.Utility
{
	public class ObjectGraphUtility
	{
		private ThingDataAccess _tda;
		public string GetThingHierarchy(int thingId)
		{
			_tda = new ThingDataAccess();
			//Inflate your parent, inflate its parent, etc
			string returnString = null;

			Thing currentThing = _tda.GetThingByID(thingId);

			List<ThingProperty> inheritedProperties = GetInheritedPropertyList(currentThing);
			currentThing.PropertyList.AddRange(inheritedProperties);
			return returnString;
		}

		private List<ThingProperty> GetInheritedPropertyList(Thing thing) 
		{
			//Thing parentThing = _tda.GetThingByID(thing.ThingTypeID);
			return null;
		}

		public string WriteThingProjectModel(Thing thing, string mapPath)
		{
			//main project folder
			string mainRepoPath = WriteFolderIfNotExists(mapPath);

			//make a folder (asp.net) for repo
			string mainRepoProjectPath = WriteFolderIfNotExists(mainRepoPath + "\\" + thing.Name);
			string mainCodeProjectPath = WriteFolderIfNotExists(mainRepoProjectPath + "\\" + thing.Name);
			string gitIgnoreContent = "*.suo";
			string gitIgnorePath = WriteFile(gitIgnoreContent, mainRepoProjectPath + "\\.gitignore");
			return mapPath;
		}

		public string WriteFile(string txt, string mapPath)
		{
			//WriteFolderIfNotExists(mapPath);

			using (StreamWriter _testData = new StreamWriter(mapPath, true))
			{
				_testData.WriteLine(txt); // Write the file.
			}

			return mapPath;
		}

		public string WriteFolderIfNotExists (string mapPath)
		{
			bool exists = System.IO.Directory.Exists(mapPath);
			if (!exists)
			{
				System.IO.Directory.CreateDirectory(mapPath);
			}

			return mapPath;
		}
		public string WriteGitRepoFolder(string mapPath)
		{

			return mapPath;
		}
	}
}