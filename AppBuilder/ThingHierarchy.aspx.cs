using AppBuilder.DAL;
using AppBuilder.Models;
using AppBuilder.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

			int thingId = GetThingId();
			//ObjectGraphUtility util = new ObjectGraphUtility();
			ThingDataAccess TDA = new ThingDataAccess();
			List <Thing> fullThingList = TDA.GetFullThingHierarchy(thingId);
			//serialize to JSON

			//txtHierarchy.Text = GetThingJSON(fullThing);
			string output = JsonConvert.SerializeObject(fullThingList, Formatting.Indented);
			txtHierarchy.Text = output.ToString();
		}

		private int GetThingId()
		{
			return Int32.Parse(Page.Request.QueryString["thingId"]);
		}

		private string GetThingJSON(Thing fullThing)
		{
			throw new NotImplementedException();
		}

		protected void btnReturn_Click(object sender, EventArgs e)
		{
			Response.Redirect("ThingList.aspx");
		}

		protected void btnWrite_Click(object sender, EventArgs e)
		{

			lblPath.Visible = true;
			//lblPath.Text = WriteThingToFile();
			lblPath.Text = WriteThingProject();
		}

		//private string WriteThingToFile()
		//{
		//	int thingId = GetThingId();
		//	//ObjectGraphUtility util = new ObjectGraphUtility();
		//	ThingDataAccess TDA = new ThingDataAccess();
		//	Thing fullThing = TDA.GetThingHierarchy(thingId);

		//	ObjectGraphUtility util = new ObjectGraphUtility();
		//	//string serverMapPath = util.WriteFile(txtHierarchy.Text, Server.MapPath("~/" + fullThing.Name));

		//	//ObjectGraphUtility utility = new ObjectGraphUtility();
		//	return serverMapPath;			
		//}

		private string WriteThingProject()
		{
			int thingId = GetThingId();
			//ObjectGraphUtility util = new ObjectGraphUtility();
			ThingDataAccess TDA = new ThingDataAccess();
			List<Thing> fullThingList = TDA.GetFullThingHierarchy(thingId);

			ObjectGraphUtility util = new ObjectGraphUtility();
			string serverMapPath = util.WriteThingProjectModel(fullThingList, Server.MapPath("~/CodeRepositories"));

			//ObjectGraphUtility utility = new ObjectGraphUtility();
			return serverMapPath;
		}

		//private string WriteThingProjectOld()
		//{
		//	int thingId = GetThingId();
		//	//ObjectGraphUtility util = new ObjectGraphUtility();
		//	ThingDataAccess TDA = new ThingDataAccess();
		//	Thing fullThing = TDA.GetThingHierarchy(thingId);

		//	ObjectGraphUtility util = new ObjectGraphUtility();
		//	string serverMapPath = util.WriteThingProjectModel(fullThing, Server.MapPath("~/CodeRepositories"));

		//	//ObjectGraphUtility utility = new ObjectGraphUtility();
		//	return serverMapPath;
		//}
	}

	
}