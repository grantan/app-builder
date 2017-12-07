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
	public partial class EditThingProperty : System.Web.UI.Page
	{
		ThingDataAccess TDA;
		ThingProperty _thingProperty;
		int _thingPropertyId;

		protected void Page_Load(object sender, EventArgs e)
		{
			_thingProperty = GetThingProperty();

			if (!IsPostBack)
			{				
				lblOwnerName.Text = "Owner Thing: " + _thingProperty.OwnerThing.Name;
				lblId.Text = _thingProperty.OwnerThing.Id.ToString();
				txtName.Text = _thingProperty.OwnedThing.Name;
				txtDescription.Text = _thingProperty.OwnedThing.Description;
				cbList.Checked = _thingProperty.IsList;
				BindPropertyDDL();
			}
		}

		private void BindPropertyDDL()
		{
			ddlTypes.DataTextField = "Name";
			ddlTypes.DataValueField = "Id";
			ddlTypes.DataSource = TDA.GetThingList();
			ddlTypes.DataBind();
			ddlTypes.SelectedValue = _thingProperty.OwnedThing.Id.ToString();
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			_thingProperty = Session["thingProperty"] != null ? (ThingProperty)Session["thingProperty"] : GetThingProperty();						
			_thingProperty.ThingPropertyId = _thingPropertyId;
			_thingProperty.OwnerThing = new Thing();
			_thingProperty.OwnerThing.Id = Int32.Parse(lblId.Text);
			_thingProperty.OwnedThing = new Thing();
			_thingProperty.OwnedThing.Id = Int32.Parse(ddlTypes.SelectedValue);
			_thingProperty.PropertyName = txtName.Text;
			_thingProperty.PropertyDescription = txtDescription.Text;
			_thingProperty.IsList = cbList.Checked;

			TDA = new ThingDataAccess();
			TDA.UpdateThingProperty(_thingProperty);
			Response.Redirect("EditThing.aspx?id=" + _thingProperty.OwnerThing.Id);
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			_thingProperty = Session["thingProperty"] != null ? (ThingProperty)Session["thingProperty"] : GetThingProperty();
			Response.Redirect("EditThing.aspx?id=" + _thingProperty.OwnerThing.Id);
		}

		private ThingProperty GetThingProperty()
		{
			_thingPropertyId = Int32.Parse(Page.Request.QueryString["id"]);
			TDA = new ThingDataAccess();
			_thingProperty = TDA.GetThingProperty(_thingPropertyId);
			Session["thingProperty"] = _thingProperty;
			return _thingProperty;
		}
	}
}