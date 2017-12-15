using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBuilder.Models
{
	public class ThingDTO
	{
		public int ParentThingId { get; set; }	
		public int ThingId { get; set; }
		public int ThingPropertyId { get; set; }

	}
}