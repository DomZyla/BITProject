using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Services : List<Service>
    {
        public Services(ServiceRequest br)
        {
            string sql = "SELECT t.timeslotId, s.Skill_ID, c.Contractor_ID, p.FirstName, p.LastName, s.SkillName, t.SlotStartTime, c.Rating " +
                "FROM TimeSlot as t, Person as p, Contractor as c, Contractor_Availability as ca, Contractor_Skill as cs, Skill as s " +
                "WHERE c.Person_ID_Ref = p.Person_ID " +
                "AND c.Contractor_ID = ca.Contractor_ID_Ref " +
                "AND c.Contractor_ID = cs.Contractor_ID_Ref " +
                "AND t.TimeSlotId = ca.TimeSlotId_Ref " +
                "AND s.Skill_ID = cs.Skill_ID_Ref " +
                "AND s.SkillName = '" + br.SkillRequestName + "' " +
                "AND t.SlotStartTime <= '"+ br.ServiceTime +"' " +
                "AND c.Rating >= '"+ br.RatingRequest +"' " +
                "AND ca.Status = 'Available'";

            SQLHelper db = new SQLHelper();

            DataTable serviceDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in serviceDataTable.Rows)
            {
                Service service = new Service(row);
                this.Add(service);

            }
        }

        /// <summary>
        /// Displays all available Contractors for the job
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="time"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        public static DataTable GetAllAvailableServices(string skill, string time, string rating)
        {
            string sql = "SELECT t.timeslotId, s.Skill_ID, c.Contractor_ID, p.FirstName, p.LastName, s.SkillName, t.SlotStartTime, c.Rating " +
                "FROM TimeSlot as t, Person as p, Contractor as c, Contractor_Availability as ca, Contractor_Skill as cs, Skill as s " +
                "WHERE c.Person_ID_Ref = p.Person_ID " +
                "AND c.Contractor_ID = ca.Contractor_ID_Ref " +
                "AND c.Contractor_ID = cs.Contractor_ID_Ref " +
                "AND t.TimeSlotId = ca.TimeSlotId_Ref " +
                "AND s.Skill_ID = cs.Skill_ID_Ref " +
                "AND s.SkillName = '" + skill + "' " +
                "AND t.SlotStartTime <= '" + time + "' " +
                "AND c.Rating >= '" + rating + "' " +
                "AND ca.Status = 'Available' " +
                "order by c.rating DESC";

            SQLHelper db = new SQLHelper();

            DataTable serviceDataTable = db.ExecuteSQL(sql);

            return serviceDataTable;
        }
    }
}
