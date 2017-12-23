using AppBuilder.DAL;
using AppBuilder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AppBuilder.Utility
{
	public class ObjectGraphUtility
	{
		private ThingDataAccess _tda;
		private FileIOUtility _fileUtil;

		public ObjectGraphUtility()
		{
			_tda = new ThingDataAccess();
			_fileUtil = new FileIOUtility();
		}

		public string GetThingHierarchy(int thingId)
		{
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

		/// <summary>
		/// Creates a repository (if necessary) and project folders (if necessary) for a ThingWebsite at the location specified by the mapPath parameter
		/// AUTOMATE THIS from main thing program
		/// </summary>
		/// <param name="thing"></param>
		/// <param name="mapPath"></param>
		/// <returns></returns>
		public string WriteThingProjectModel(Thing thing, string mapPath)
		{
			//main project folder
			string mainRepoPath = _fileUtil.WriteFolderIfNotExists(mapPath);

			//make a folder (git) for repo
			string mainRepoProjectPath = _fileUtil.WriteFolderIfNotExists(mainRepoPath + "\\" + thing.Name);

			string webConfigContent = GetBasicWebConfigContent();
			string webConfigPath = _fileUtil.WriteFile(webConfigContent, mainRepoProjectPath + "\\web.config");
			//TODO put together the .gitignore file here from configurable xml or something
			//string gitIgnoreContent = "*.suo";
			string gitIgnoreContent = GetBasicGitIgnoreContent();
			string gitIgnorePath = _fileUtil.WriteFile(gitIgnoreContent, mainRepoProjectPath + "\\.gitignore");

			//make a folder (asp.net) for website code and resources
			string mainCodeProjectPath = _fileUtil.WriteFolderIfNotExists(mainRepoProjectPath + "\\" + thing.Name);

			//Write the Domain model folder
			string modelsFolderPath = _fileUtil.WriteFolderIfNotExists(mainCodeProjectPath + "\\models");



			

			return mapPath;
		}

		private string GetBasicWebConfigContent()
		{
			StringBuilder sb = new StringBuilder();
			string webConfigContent = "<? xml version = \"1.0\" encoding = \"utf-8\" ?> < !-- For more information on how to configure your ASP.NET application, please visit https://go.microsoft.com/fwlink/?LinkId=169433 -->< configuration >";
			return webConfigContent;
		}

		/// <summary>
		/// TODO This could read a basic .gitignore file or copy the file
		/// </summary>
		/// <returns></returns>
		private string GetBasicGitIgnoreContent()
		{
			StringBuilder sb = new StringBuilder();
			string gitIgnoreContent = "*.suo";

			return gitIgnoreContent;
		}

		public string WriteGitRepoFolder(string mapPath)
		{

			return mapPath;
		}
	}
}