using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Service : INotifyPropertyChanged
    {

        /// <summary>
        /// private properties
        /// </summary>
        private int _skillId;
        private int _contractorId;
        private string _firstName;
        private string _lastName;
        private string _skillName;
        private string _startTime;
        private int _timeSlotId;
        private int _rating;

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
        /// public properties
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

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
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
            }
        }

        public string StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public int TimeSlotId
        {
            get
            {
                return _timeSlotId;
            }
            set
            {
                _timeSlotId = value;
            }
        }

        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }

        public Service()
        {

        }

        /// <summary>
        /// Datarow for services
        /// </summary>
        /// <param name="dr"></param>
        public Service(DataRow dr)
        {
            TimeSlotId = Convert.ToInt32(dr["timeSlotId"]);
            ContractorId = Convert.ToInt32(dr["contractor_Id"]);
            SkillId = Convert.ToInt32(dr["skill_Id"]);
            FirstName = dr["firstName"].ToString();
            LastName = dr["lastName"].ToString();
            SkillName = dr["skillName"].ToString();
            StartTime = dr["firstName"].ToString();
            Rating = Convert.ToInt32(dr["rating"]);
        }



    }
}
