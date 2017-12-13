using AppBuilder.DAL;
using AppBuilder.Models;
using AppBuilder.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBuilder
{
	public partial class ThingHierarchy : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{			
			int thingId = Int32.Parse(Page.Request.QueryString["thingId"]);
			//ObjectGraphUtility util = new ObjectGraphUtility();
			ThingDataAccess TDA = new ThingDataAccess();
			Thing fullThing = TDA.GetThingHierarchy(thingId);
			
		}		
	}

	
}