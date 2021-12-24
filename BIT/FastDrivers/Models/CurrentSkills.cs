using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class CurrentSkills : List<ContractorSkill>
    {
        public CurrentSkills(Contractor selectedContractor)
        {
            //Get all the skills details from the db
            SQLHelper db = new SQLHelper();

            string sql = "select cs.Contractor_Skill_ID, c.Contractor_ID, s.Skill_ID, s.SkillName, s.Description from Skill as s, Contractor as c, Person as p, Contractor_Skill as cs " +
                $"where c.contractor_Id = {selectedContractor.ContractorId} " +
                "AND c.Contractor_ID = cs.Contractor_ID_Ref " +
                "AND s.Skill_ID = cs.Skill_ID_Ref " +
                "AND p.Status = 1 " +
                "AND p.Person_ID = c.Person_ID_Ref";

            DataTable contractorSkillsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in contractorSkillsDataTable.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(row);
                this.Add(contractorSkill);

            }
        }
    }
}
