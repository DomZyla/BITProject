using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class AvailableJobs : List<AvailableJob>
    {

        public AvailableJobs()
        {
            //Get all the availableJobs details from the db
            SQLHelper db = new SQLHelper();

            string sql = "SELECT  jr.JobRequest_ID, cl.Client_ID ,p.FirstName , s.SkillName, jhl.Date, jhl.StartTime, jr.RequestStatus, jr.Kilometers " +
                "FROM Job_Request as jr,  Skill as s, Contractor as c, Job_Hour_Log as jhl, Person as p, Client as cl, Location as l " +
                "WHERE s.Skill_ID = jr.Skill_ID_Ref " +
                "AND c.Contractor_ID = jr.Contractor_ID_Ref " +
                "AND jhl.JobRequest_Ref = jr.JobRequest_ID " +
                "AND p.Person_ID = c.Person_ID_Ref " +
                "AND cl.Client_ID = l.Client_ID_Ref " +
                "AND l.Location_ID = jr.Location_Ref ";

            DataTable availableJobsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in availableJobsDataTable.Rows)
            {
                AvailableJob availableJob = new AvailableJob(row);
                this.Add(availableJob);

            }
        }
    }
}
