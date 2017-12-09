using AppBuilder.DAL;
using AppBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBuilder
{
	public partial class NewThing : System.Web.UI.Page
	{
		ThingDataAccess TDA;

		protected void Page_Load(object sender, EventArgs e)
		{
			TDA = new ThingDataAccess();
			LoadThingDDL();
		}

		private void LoadThingDDL()
		{
			List<Thing> thingList = TDA.GetThingList();
			if (thingList != null)
			{
				ddlTypes.DataTextField = "Name";
				ddlTypes.DataValueField = "Id";
				ddlTypes.DataSource = thingList;
				ddlTypes.DataBind();
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			Thing newThing = new Thing();
			newThing.Name = txtName.Text;
			newThing.Description = txtDescription.Text;
			newThing.ThingTypeID = Int32.Parse(ddlTypes.SelectedValue);
			int thingID = SaveThing(newThing);
			//SaveThingInheritance(newThing.ThingTypeID, thingID);
			Page.Response.Redirect("ThingList.aspx");
		}

		//private void SaveThingInheritance(int thingTypeID, int thingID)
		//{
		//	TDA.SaveThingInheritance(thingTypeID, thingID);
		//}

		private int SaveThing(Thing newThing)
		{			
			return TDA.NewThing(newThing).Id;
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("ThingList.aspx");
		}
	}
}