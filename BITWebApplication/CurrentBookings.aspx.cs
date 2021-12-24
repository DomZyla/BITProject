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
    public partial class CurrentBookings : System.Web.UI.Page
    {

        /// <summary>
        /// Calls the data from the database to display in the datagrid(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClientID"] != null) 
            {

                Client client = new Client();
                client.ClientId = Convert.ToInt32(Session["ClientID"]);

                gvCurrentBookings.DataSource = client.AllBookings();

                gvCurrentBookings.DataBind();

            }
            else if (Session["ContractorId"] != null) 
            {

                string sql = "SELECT  jr.JobRequest_ID, cl.Client_ID ,p.FirstName, s.SkillName, jhl.Date, jhl.StartTime, jr.RequestStatus, jr.Kilometers " +
                "FROM Job_Request as jr,  Skill as s, Contractor as c, Job_Hour_Log as jhl, Person as p, Client as cl, Location as l " +
                "WHERE s.Skill_ID = jr.Skill_ID_Ref " +
                "AND c.Contractor_ID = jr.Contractor_ID_Ref " +
                "AND jhl.JobRequest_Ref = jr.JobRequest_ID " +
                "AND p.Person_ID = c.Person_ID_Ref " +
                "AND cl.Client_ID = l.Client_ID_Ref " +
                "AND l.Location_ID = jr.Location_Ref " +
                "AND c.Contractor_ID = " + Convert.ToInt32(Session["ContractorId"]) +
                " order by jhl.Date";

                SQLHelper sqlHelper = new SQLHelper();

                DataTable dataTable = sqlHelper.ExecuteSQL(sql);

                gvCurrentBookings.DataSource = dataTable;
                gvCurrentBookings.DataBind();
            }


        }
    }
}