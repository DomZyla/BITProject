using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Button that checks the entered detail of the login and based on results will allow permissions for different Buttons and functionality (Client, Contractor, Coordinator)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "select * from Person as p, Client as c where p.Person_ID = c.Person_ID_Ref AND username ='" + txtUser.Text + "' and password='" + txtPassword.Text + "'";

            SQLHelper sqlHelper = new SQLHelper();

            DataTable dataTable = sqlHelper.ExecuteSQL(sql);

            if(dataTable.Rows.Count == 1)
            {
                Session["role"] = "client";

                DataRow row = dataTable.Rows[0];

                Session["Name"] = row["firstname"];

                Session["ClientID"] = row["Client_ID"];

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                sql = "select * from Person as p, Contractor as c where p.Person_ID = c.Person_ID_Ref AND username ='" + txtUser.Text + "' and password='" + txtPassword.Text + "'";

                dataTable = sqlHelper.ExecuteSQL(sql);

                if (dataTable.Rows.Count == 1)
                {
                    Session["role"] = "contractor";

                    DataRow row = dataTable.Rows[0];

                    Session["Name"] = row["firstname"];

                    Session["ContractorId"] = row["Contractor_ID"];

                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    sql = "select * from Person as p, Coordinator as c where p.Person_ID = c.Person_ID_Ref AND username ='" + txtUser.Text + "' and password='" + txtPassword.Text + "'";

                    dataTable = sqlHelper.ExecuteSQL(sql);

                    if (dataTable.Rows.Count == 1)
                    {
                        Session["role"] = "coordinator";

                        DataRow row = dataTable.Rows[0];

                        Session["Name"] = row["firstname"];

                        Session["CoordinatorId"] = row["Coordinator_ID"];

                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = ("Username and/or Password does not match");
                    }
                }

            }

            lblErrorMessage.Text = ("Username and/or Password does not match");
        }
    }
}