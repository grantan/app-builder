using AppBuilder.DAL;
using AppBuilder.Models;
using Newtonsoft.Json;
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
		private ThingPropertyDataAccess _tpda;
		
		public ObjectGraphUtility()
		{
			_tda = new ThingDataAccess();
			_tpda = new ThingPropertyDataAccess();
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

		
	}
}