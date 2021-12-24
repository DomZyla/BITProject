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
    public class AvailableJob
    {
        /// <summary>
        /// Private Properties
        /// </summary>
        private int _jobRequestId;
        private int _clientId;
        private string _firstName;
        private string _skillName;
        private DateTime _date;
        private string _startTime;
        private string _requestStatus;
        private int _kilometers;

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
        /// Public Properties
        /// </summary>
        public int JobRequestId
        {
            get
            {
                return _jobRequestId;
            }
            set
            {
                _jobRequestId = value;
            }

        }

        public int ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                _clientId = value;
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

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string RequestStatus
        {
            get
            {
                return _requestStatus;
            }
            set
            {
                _requestStatus = value;
            }
        }

        public int Kilometers
        {
            get
            {
                return _kilometers;
            }
            set
            {
                _kilometers = value;
            }

        }


        public AvailableJob()
        {

        }

        /// <summary>
        /// DataRow for AvailableJob
        /// </summary>
        /// <param name="dr"></param>
        public AvailableJob(DataRow dr)
        {
            JobRequestId = Convert.ToInt32(dr["jobRequest_Id"]);
            ClientId = Convert.ToInt32(dr["client_Id"]);
            FirstName = dr["firstName"].ToString();
            SkillName = dr["skillName"].ToString();
            Date = Convert.ToDateTime(dr["date"]);
            StartTime = dr["startTime"].ToString();
            RequestStatus = dr["requestStatus"].ToString();
            Kilometers = Convert.ToInt32(dr["kilometers"]);
        }

    }
}
