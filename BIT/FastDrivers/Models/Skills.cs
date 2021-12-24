using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Skills : List<Skill>
    {
        public Skills()
        {
            //Get all the skills details from the db
            SQLHelper db = new SQLHelper();

            string sql = "select Skill_ID, SkillName,Description from Skill";

            DataTable skillsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in skillsDataTable.Rows)
            {
                Skill skill = new Skill(row);
                this.Add(skill);

            }
        }
    }
}
