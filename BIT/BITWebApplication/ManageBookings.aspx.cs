using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApplication
{
    public partial class ManageBookings : System.Web.UI.Page
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
                if (Session["CoordinatorId"] != null)
                {
                    Coordinator coordinator = new Coordinator();
                    coordinator.CoordinatorId = Convert.ToInt32(Session["CoordinatorId"]);

                    gvCurrentSessions.DataSource = coordinator.AllBookings();
                    gvManageSessions.DataSource = coordinator.AllCompletedBookings();
                    gvPastSessions.DataSource = coordinator.AllPastBookings();

                    gvCurrentSessions.DataBind();
                    gvManageSessions.DataBind();
                    gvPastSessions.DataBind();
                }
            }
        }

        protected void gvCurrentSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        /// <summary>
        /// Creates functionality for the buttons in the datagrid when a selection is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvManageSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Verify")
            {
                SQLHelper _db = new SQLHelper();

                GridViewRow row = gvManageSessions.Rows[rowIndex];

                string sql = "UPDATE Job_Request " +
                            "SET RequestStatus = 'Verified' " +
                            "WHERE JobRequest_ID = " + Convert.ToInt32(row.Cells[0].Text);

                _db.ExecuteNonQuery(sql);
            }
            else if (e.CommandName == "SendForPayment")
            {
                SQLHelper _db = new SQLHelper();

                GridViewRow row = gvManageSessions.Rows[rowIndex];

                string sql = "UPDATE Job_Request " +
                            "SET RequestStatus = 'Send for payment' " +
                            "WHERE JobRequest_ID = " + Convert.ToInt32(row.Cells[0].Text);

                _db.ExecuteNonQuery(sql);
            }
            Response.Redirect("ManageBookings.aspx");
        }

        protected void gvPastSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}