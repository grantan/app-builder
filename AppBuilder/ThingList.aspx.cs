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
			int id=0;
			var lb = (LinkButton)sender;
			var row = (GridViewRow)lb.NamingContainer;
			if (row != null)
			{
				var lblId = row.FindControl("lblId") as Label;
				id = Int32.Parse(lblId.Text);
				//var lblRequestType = row.FindControl("lblRequestType") as Label;
				//var lblStatus = row.FindControl("lblStatus") as Label;

				//if (lblRequestType != null && lblRequestor != null && lblStatus != null)
				//{
				//	//Get values
				//	string requestor = lblRequestor.Text;
				//	string requestType = lblRequestType.Text;
				//	string status = lblStatus.Text;
				//}

			}


			//int id = Int32.Parse(gvThings.SelectedRow.Cells[1].Text);
			Page.Response.Redirect("EditThing.aspx?id="+id); 

		}

		protected void btnNewThing_Click(object sender, EventArgs e)
		{
			Response.Redirect("NewThing.aspx");
		}
	}
}