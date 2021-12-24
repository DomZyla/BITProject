using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class ContractorSkills : List<ContractorSkill>
    {
        public ContractorSkills(Contractor selectedContractor)
        {
            //Get all the skills details from the db
            SQLHelper db = new SQLHelper();

            string sql = "select c.Contractor_ID, s.Skill_ID, s.SkillName, s.Description from Skill as s, Contractor as c, Person as p " +
                $"where c.contractor_Id = {selectedContractor.ContractorId} " +
                "AND p.Status = 1 " +
                "AND p.Person_ID = c.Person_ID_Ref";

            //string sql = "select skill_ID, SkillName, Description from Skill " +
            //        "where Skill_ID not in " +
            //        $"(select Skill_ID_Ref from Contractor_Skill where Contractor_ID_Ref = {selectedContractor.ContractorId})";

            DataTable contractorSkillsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in contractorSkillsDataTable.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(row);
                this.Add(contractorSkill);

            }

        }
    }
}
