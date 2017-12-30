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
	public partial class AddThingProperty : System.Web.UI.Page
	{
		ThingPropertyDataAccess TPDA;
		ThingDataAccess TDA;
		int _id;

		protected void Page_Load(object sender, EventArgs e)
		{
			_id = Int32.Parse(Page.Request.QueryString["id"]);
			if (!IsPostBack)
			{
				
				TDA = new ThingDataAccess();
				Thing thing = LoadThing(_id);
				lblOwnerName.Text = "Owner Thing: " + thing.Name;

				BindPropertyDDL();
			}
		}

		private void BindPropertyDDL()
		{
			ddlTypes.DataTextField = "Name";
			ddlTypes.DataValueField = "Id";
			ddlTypes.DataSource = TDA.GetThingList();
			ddlTypes.DataBind();
		}

		private Thing LoadThing(int id)
		{
			Thing thing = TDA.GetThingByID(id);
			return thing;
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			int ownerId = _id;
			int propertyId = Int32.Parse(ddlTypes.SelectedValue);
			TPDA = new ThingPropertyDataAccess();
			TPDA.InsertThingProperty(ownerId, propertyId, txtName.Text, txtDescription.Text, cbList.Checked, 0);
			Response.Redirect("EditThing.aspx?id="+ownerId);
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			_id = Int32.Parse(Page.Request.QueryString["id"]);
			Response.Redirect("EditThing.aspx?id=" + _id);
		}
	}
}