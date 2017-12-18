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
		ThingPropertyDataAccess TPDA;
		ThingDataAccess TDA;
		Thing _ownerThing;
		ThingProperty _thingProperty;
		int _thingPropertyId;

		protected void Page_Load(object sender, EventArgs e)
		{
			//_ownerThing = (Thing)Session["OwnerThing"];
			//_thingPropertyId = Int32.Parse(Session["ThingPropertyId"].ToString());
			_thingPropertyId = GetThingPropertyId();
			_thingProperty = GetThingProperty(_thingPropertyId);
			_ownerThing = GetOwnerByThingPropertyId(_thingPropertyId);

			Session["ThingProperty"] = _thingProperty;
			Session["OwnerThing"] = _ownerThing;

			if (!IsPostBack)
			{				
				lblOwnerName.Text = "Owner Thing: " + _ownerThing.Name;
				lblId.Text = _ownerThing.Id.ToString();
				txtName.Text = _thingProperty.PropertyName;
				txtDescription.Text = _thingProperty.PropertyDescription;
				cbList.Checked = _thingProperty.IsList;
				txtOrder.Text = _thingProperty.SequenceOrder.ToString();
				BindPropertyDDL();
			}
		}

		private Thing GetOwnerByThingPropertyId(int thingPropertyId)
		{
			Thing ownerThing = TPDA.GetOwnerByThingPropertyId(thingPropertyId);
			return ownerThing;
		}

		private int GetThingPropertyId()
		{
			int thingPropertyId = Int32.Parse(Page.Request.QueryString["thingPropertyId"]);
			return thingPropertyId;
		}

		private void BindPropertyDDL()
		{
			TDA = new ThingDataAccess();
			ddlTypes.DataTextField = "Name";
			ddlTypes.DataValueField = "Id";
			ddlTypes.DataSource = TDA.GetThingList();
			ddlTypes.DataBind();
			ddlTypes.SelectedValue = _thingProperty.OwnedThing.Id.ToString();
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{			
			_thingProperty = Session["ThingProperty"] != null ? (ThingProperty)Session["ThingProperty"] : GetThingProperty(GetThingPropertyId());						
			_thingProperty.ThingPropertyId = _thingPropertyId;
			_thingProperty.OwnedThing = new Thing();
			_thingProperty.OwnedThing.Id = Int32.Parse(ddlTypes.SelectedValue);
			_thingProperty.PropertyName = txtName.Text;
			_thingProperty.PropertyDescription = txtDescription.Text;
			_thingProperty.IsList = cbList.Checked;
			_thingProperty.SequenceOrder = Int32.Parse(txtOrder.Text);

			TPDA = new ThingPropertyDataAccess();
			TPDA.UpdateThingProperty(_thingProperty);
			_ownerThing = (Thing)Session["OwnerThing"];
			Response.Redirect("EditThing.aspx?id=" + _ownerThing.Id);
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			//_thingPropertyId = Int32.Parse(Session["ThingPropertyId"].ToString());
			//_thingProperty = Session["ThingProperty"] != null ? (ThingProperty)Session["ThingProperty"] : GetThingProperty(_thingPropertyId);
			_ownerThing = (Thing)Session["OwnerThing"];
			Response.Redirect("EditThing.aspx?id=" + _ownerThing.Id);
		}

		private ThingProperty GetThingProperty(int thingPropertyId)
		{
			TPDA = new ThingPropertyDataAccess();
			_thingPropertyId = GetThingPropertyId();
			_thingProperty = TPDA.GetThingProperty(_thingPropertyId);
			Session["ThingProperty"] = _thingProperty;
			return _thingProperty;
		}
	}
}