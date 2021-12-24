using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.Models
{
    public class ContractorSkill : INotifyPropertyChanged
    {

        /// <summary>
        /// private properties 
        /// </summary>
        private int _skillId;
        private int _contractorId;
        private string _skillName;
        private string _description;

        private SQLHelper _db;

        //declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                //calling the event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        
        /// <summary>
        /// Public properties
        /// </summary>
        public int ContractorId
        {
            get
            {
                return _contractorId;
            }
            set
            {
                _contractorId = value;
            }
        }

        public int SkillId
        {
            get
            {
                return _skillId;
            }
            set
            {
                _skillId = value;
            }
        }

        public string SkillName
        {
            get
            {
                return _skillName;
            }
            set
            {
                _skillName = value;
                OnPropertyChanged("SkillName");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public ContractorSkill()
        {

        }

        /// <summary>
        /// Datarow for contractor skills
        /// </summary>
        /// <param name="dr"></param>
        public ContractorSkill(DataRow dr)
        {
            SkillId = Convert.ToInt32(dr["skill_Id"]);
            ContractorId = Convert.ToInt32(dr["contractor_Id"]);
            SkillName = dr["skillName"].ToString();
            Description = dr["description"].ToString();
        }

        /// <summary>
        /// Object for assigning a skill to a contractor
        /// </summary>
        public void AssignSkill()
        {
            _db = new SQLHelper();

            string sql2 = "Select * From Contractor_skill " +
                        "where skill_Id_Ref = " + SkillId +
                        " and contractor_Id_Ref = " + ContractorId;

            

            DataTable contractorSkillsDataTable = _db.ExecuteSQL(sql2);

            if (contractorSkillsDataTable.Rows.Count == 0)
            {
                string sql = "INSERT into Contractor_Skill(Contractor_Id_Ref,Skill_Id_Ref) " +
                    "VALUES ('" + ContractorId + "','" + SkillId + "')";
                _db.ExecuteNonQuery(sql);
                MessageBox.Show("Assigned contractor details successfully");
            }
            else
            {
                MessageBox.Show("Duplicate Skill cannot be added");
            }
        }

        /// <summary>
        /// Object for removing a skill from a contractor
        /// </summary>
        public void DeleteContractorSkill()
        {
            _db = new SQLHelper();

            string sql2 = "Select * From Contractor_skill " +
                        "where skill_Id_Ref = " + SkillId +
                        " and contractor_Id_Ref = " + ContractorId;



            DataTable contractorSkillsDataTable = _db.ExecuteSQL(sql2);


            if (contractorSkillsDataTable.Rows.Count > 0) 
            { 
            string sql = "DELETE FROM Contractor_Skill " +
                "where skill_Id_Ref = @skill_Id " +
                "and contractor_Id_Ref = @contractor_Id ";

            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@contractor_Id", DbType.Int32);
            parameters[0].Value = ContractorId;

            parameters[1] = new SqlParameter("@skill_Id", DbType.Int32);
            parameters[1].Value = SkillId;

            _db.ExecuteNonQuery(sql, parameters);
            MessageBox.Show("Skill has been Removed successfully");
            }
            else
            {
                MessageBox.Show("Cannot Remove a Skill that is not added");
            }
        }
    }
}
