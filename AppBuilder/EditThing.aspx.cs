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
	public partial class EditThing : System.Web.UI.Page
	{
		ThingDataAccess TDA;
		ThingPropertyDataAccess TPDA;
		Thing _thing;
		int _thingId;

		protected void Page_Load(object sender, EventArgs e)
		{
			TDA = new ThingDataAccess();
			
			_thing = LoadThing(GetThingId());
			Session["OwnerThing"] = _thing;
			if(!IsPostBack)
			{
				txtId.Text = _thing.Id.ToString();
				txtDescription.Text = _thing.Description;
				txtName.Text = _thing.Name;

				LoadThingDDL();
				ddlTypes.SelectedValue = _thing.ThingTypeID.ToString();
				LoadPropertiesGrid(_thing.Id);				
			}
		}

		private int GetThingId()
		{
			int id = Int32.Parse(Page.Request.QueryString["id"]);
			return id;
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

		private Thing LoadThing(int id)
		{
			Thing thing = TDA.GetThingByID(id);
			return thing;
		}

		private void LoadPropertiesGrid(int ownerId)
		{
			TPDA = new ThingPropertyDataAccess();
			List<ThingProperty> propertyList = TPDA.GetThingProperties(ownerId);
			if (propertyList != null)
			{
				gvProperties.DataSource = propertyList;
				gvProperties.DataBind();
			}
		}	

		protected void gvProperties_SelectedIndexChanged(object sender, EventArgs e)
		{
			int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;			
			int id = Convert.ToInt32(gvProperties.DataKeys[rowIndex].Values[0]);

			Page.Response.Redirect("EditThingProperty.aspx?thingPropertyId="+ id);
		}

		protected void gvProperties_RowCommand(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{
				// Retrieve the row index stored in the 
				// CommandArgument property.
				int index = Convert.ToInt32(e.CommandArgument);

				TPDA = new ThingPropertyDataAccess();
				TPDA.DeleteThingProperty(index);
				_thing = Session["OwnerThing"] as Thing;
				LoadPropertiesGrid(_thing.Id);
			}

		}

		protected void btnAddProperty_Click(object sender, EventArgs e)
		{
			int ownerId = Int32.Parse(txtId.Text);
			Response.Redirect("AddThingProperty.aspx?id=" + ownerId);
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("ThingList.aspx");
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			Thing updatedThing = new Thing();
			updatedThing.Id = Int32.Parse(txtId.Text);
			updatedThing.Name = txtName.Text;
			updatedThing.Description = txtDescription.Text;
			updatedThing.ThingTypeID = Int32.Parse(ddlTypes.SelectedValue);
			TDA.EditThing(updatedThing);
			Page.Response.Redirect("ThingList.aspx");
		}
	}
}