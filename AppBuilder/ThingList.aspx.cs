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
	public partial class ThingList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				BindGrid();
			}
		}

		private void BindGrid()
		{
			ThingDataAccess TDA = new ThingDataAccess();
			gvThings.DataSource = TDA.GetThingList();
			gvThings.DataBind();
		}

		protected void gvThings_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Determine the RowIndex of the Row whose Button was clicked.
			int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

			//Get the value of column from the DataKeys using the RowIndex.
			int id = Convert.ToInt32(gvThings.DataKeys[rowIndex].Values[0]);

			Page.Response.Redirect("EditThing.aspx?id="+id); 

		}

		protected void gvThings_RowCommand(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "Hierarchy")
			{
				// Retrieve the row index stored in the 
				// CommandArgument property.
				int index = Convert.ToInt32(e.CommandArgument);
				Response.Redirect("ThingHierarchy.aspx?thingId=" + index);				
			}

		}

		protected void btnNewThing_Click(object sender, EventArgs e)
		{
			Response.Redirect("NewThing.aspx");
		}
	}
}