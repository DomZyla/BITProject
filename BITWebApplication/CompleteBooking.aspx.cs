using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApplication
{
    public partial class CompleteBooking : System.Web.UI.Page
    {
        /// <summary>
        /// Requests the Id of the Job Request that was selected to be Completed and Kilometers added 
        /// and displays it into the txtRequestJobId textbox for use in the sql query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            txtRequestJobId.Text = Request.QueryString["Id"].ToString();
        }

        /// <summary>
        /// Button for updating a Job Request to Completed and adding the kilometers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (CustomKilometerValidator.IsValid)
            {
                SQLHelper _db = new SQLHelper();

                string sql = "Update Job_Request " +
                    "SET RequestStatus = 'Completed', " +
                    "Kilometers =" + txtKilometers.Text +
                    " WHERE JobRequest_ID =" + Convert.ToInt32(Request.QueryString["Id"]);

                int isCompleted = _db.ExecuteNonQuery(sql);

                if (isCompleted > 0)
                {
                    Response.Redirect("UpdateBookings.aspx");
                }
            }
        }

        /// <summary>
        /// A custom validator for selecting a date in the calander
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomKilometerValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int n;
            bool isNumeric = int.TryParse(txtKilometers.Text, out n);

            if (isNumeric)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}