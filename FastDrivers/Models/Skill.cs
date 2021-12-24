using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Skill :INotifyPropertyChanged, IDataErrorInfo
    {

        /// <summary>
        /// private properties
        /// </summary>
        private int _skillId;
        private string _skillName;
        private string _description;

        public Dictionary<string, string> ErrorCollection { get; set; } = new Dictionary<string, string>();

        public string Error
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Validation for string entries to not be null
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "SkillName":
                        if (string.IsNullOrWhiteSpace(SkillName))
                        {
                            result = "SkillName cannot be empty";
                        }
                        break;

                    case "Description":
                        if (string.IsNullOrWhiteSpace(Description))
                        {
                            result = "Description cannot be empty";
                        }
                        break;
                }
                if (result != null)
                {
                    ErrorCollection.Add(propertyName, result);
                }
                OnPropertyChanged("ErrorCollection");

                return result;
            }
        }

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

        public Skill()
        {

        }

        /// <summary>
        /// Datarow for skills
        /// </summary>
        /// <param name="dr"></param>
        public Skill(DataRow dr)
        {
            SkillId = Convert.ToInt32(dr["skill_Id"]);
            SkillName = dr["skillName"].ToString();
            Description = dr["description"].ToString();
        }

        /// <summary>
        /// Update skill object
        /// </summary>
        public void UpdateSkill()
        {
            string sql = "Update Skill set Description= @description, " +
                       "skillName = @skillName " +
                       "where skill_Id = @skill_Id";

            _db = new SQLHelper();

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@description", DbType.String);
            parameters[0].Value = Description;

            parameters[1] = new SqlParameter("@skillName", DbType.Int32);
            parameters[1].Value = SkillName;

            parameters[2] = new SqlParameter("@skill_Id", DbType.Int32);
            parameters[2].Value = SkillId;

            _db.ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// insert skill object
        /// </summary>
        public void InsertSkill()
        {
            string sql = "INSERT into Skill(SkillName,Description) " +
            "VALUES ('" + SkillName + "','" + Description + "')";

            _db = new SQLHelper();

            _db.ExecuteNonQuery(sql);
        }
    }
}
