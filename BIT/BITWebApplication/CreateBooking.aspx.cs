using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApplication
{
    public partial class CreateBooking : System.Web.UI.Page
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

                    gvAvailableClients.DataSource = coordinator.AllClients();

                    gvAvailableClients.DataBind();
                }
            }
        }

        /// <summary>
        /// Creates functionality for the buttons in the datagrid to make a selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAvailableClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                GridViewRow row = gvAvailableClients.Rows[rowIndex];

                txtClientID.Text = row.Cells[0].Text.ToString();
            }
        }

        /// <summary>
        /// Custom Validator for the calander to pick a date
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void customBookingDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (calBookingDate.SelectedDate == null || calBookingDate.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// Button to Display data in the datagrid based on selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (customBookingDateValidator.IsValid)
            {
                GenerateSessions();
            }
        }

        /// <summary>
        /// Calls the data from the database to display in the datagrid(s)
        /// </summary>
        private void GenerateSessions()
        {
            DataTable data = Services.GetAllAvailableServices(ddlServiceSkills.SelectedValue, ddlTime.SelectedValue, ddlRating.SelectedValue);

            gvAvailableSessions.DataSource = data;
            gvAvailableSessions.DataBind();
        }

        /// <summary>
        /// Creates functionality for the buttons in the datagrid when a selection is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAvailableSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Assign")
            {
                SQLHelper _db = new SQLHelper();

                GridViewRow row = gvAvailableSessions.Rows[rowIndex];

                string sql = "Set Identity_Insert Job_Hour_Log ON " +
                    "declare @JobRequest_Id int " +
                    "insert into Job_Request (Location_ref, Skill_Id_Ref, Contractor_Id_Ref, RequestDate, RequestStatus, Kilometers) " +
                    "Values (" + txtClientID.Text + " , " + Convert.ToInt32(row.Cells[3].Text) + " , " + Convert.ToInt32(row.Cells[0].Text) + " , '" + Convert.ToDateTime(calBookingDate.SelectedDate).ToString("yyyy-MM-dd") + "' , 'Pending' , 0 )" +
                    "set @JobRequest_Id = SCOPE_IDENTITY() " +
                    "insert into Job_Hour_Log (JobRequest_Ref, Date, StartTime, EndTime) " +
                    "values (@JobRequest_Id, '" + Convert.ToDateTime(calBookingDate.SelectedDate).ToString("yyyy-MM-dd") + "','" + ddlTime.SelectedValue + "', '18:00:00')";

                int rowsAffected = _db.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    Response.Redirect("ManageBookings.aspx");
                }
            }
        }
    }
}