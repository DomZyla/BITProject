using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApplication
{
    public partial class SiteMaster : MasterPage
    {

        /// <summary>
        /// Displays different links to parts of the website based on who is logged in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"]!=null && !string.IsNullOrEmpty(Session["role"].ToString()))
            {
                string role = Session["role"].ToString();

                lnkBtnLogin.Visible = false;
                lnkBtnSignUp.Visible = false;
                lnkBtnLogout.Visible = true;


                if (Session["Name"] != null && !string.IsNullOrEmpty(Session["Name"].ToString()))
                {
                    lblWelcomeMsg.Text = "Welcome " + Session["Name"].ToString();
                }

                if(role.ToLower() == "client")
                {
                    lnkNewBooking.Visible = true;
                }

                switch (role.ToLower())
                {
                    case "client":
                        lnkNewBooking.Visible = true;
                        lnkCurrentBookings.Visible = true;

                        break;

                    case "contractor":
                        lnkCurrentBookings.Visible = true;
                        lnkUpdateBookings.Visible = true;

                        break;

                    case "coordinator":
                        lnkManageBookings.Visible = true;
                        lnkCreateBooking.Visible = true;

                        break;
                }
            }
        }

        /// <summary>
        /// Button that directs to the login.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        /// <summary>
        /// Sign Up Button Placeholder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBtnSignUp_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Button that directs to the NewBooking.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkNewBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewBooking.aspx");
        }

        /// <summary>
        /// Button that directs to the CurrentBookings.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCurrentBookings_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurrentBookings.aspx");
        }

        /// <summary>
        /// Button that directs to the HomePage.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("HomePage.aspx");
        }

        /// <summary>
        /// Button that directs to the UpdateBookings.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkUpdateBookings_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateBookings.aspx");
        }

        /// <summary>
        /// Button that directs to the ManageBookings.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkManageBookings_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBookings.aspx");
        }

        /// <summary>
        /// Button that directs to the CreateBooking.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCreateBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateBooking.aspx");
        }
    }
}