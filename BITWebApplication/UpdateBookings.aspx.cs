using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApplication
{
    public partial class UpdateBookings : System.Web.UI.Page
    {
        /// <summary>
        /// Calls the data from the database to display in the datagrid(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                if (Session["ContractorId"] != null)
                {

                    Contractor contractor = new Contractor();
                    contractor.ContractorId = Convert.ToInt32(Session["ContractorId"]);

                    gvUpdateSessions.DataSource = contractor.AllContractorBookings();
                    gvProgressSessions.DataSource = contractor.AllProgressContractorBookings();

                    gvUpdateSessions.DataBind();
                    gvProgressSessions.DataBind();

                }
            }
        }

        /// <summary>
        /// Creates functionality for the buttons in the datagrid when a selection is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUpdateSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Accept")
            {
                SQLHelper _db = new SQLHelper();

                GridViewRow row = gvUpdateSessions.Rows[rowIndex];

                string sql = "UPDATE Job_Request " +
                            "SET RequestStatus = 'Approved' " +
                            "WHERE JobRequest_ID = " + Convert.ToInt32(row.Cells[0].Text);

                _db.ExecuteNonQuery(sql);
            }
            else if (e.CommandName == "Reject")
            {
                SQLHelper _db = new SQLHelper();

                GridViewRow row = gvUpdateSessions.Rows[rowIndex];

                string sql = "UPDATE Job_Request " +
                            "SET RequestStatus = 'Rejected' " +
                            "WHERE JobRequest_ID = " + Convert.ToInt32(row.Cells[0].Text);

                _db.ExecuteNonQuery(sql);
            }
            Response.Redirect("UpdateBookings.aspx");
        }

        /// <summary>
        /// Creates functionality for the buttons in the datagrid when a selection is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProgressSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProgressSessions.Rows[rowIndex];
            if (e.CommandName == "Complete")
            {
                Response.Redirect("CompleteBooking.aspx?Id=" + Convert.ToInt32(row.Cells[0].Text));
            }
        }
    }
}