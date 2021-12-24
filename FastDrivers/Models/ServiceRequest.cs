using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class ServiceRequest : INotifyPropertyChanged, IDataErrorInfo
    {
        
        /// <summary>
        /// private properties
        /// </summary>
        private DateTime _date;
        private string _serviceTime;
        private string _skillName;
        private int _rating;
        private int _clientId;

        private Skills _skills;
        private Contractors _contractors;
        private TimeSlots _timeSlots;

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
                switch(propertyName)
                {
                    case "ServiceTime":
                        if(string.IsNullOrWhiteSpace(ServiceTime))
                        {
                            result = "Time of Service cannot be empty";
                        }
                        break;

                    case "SkillRequestName":
                        if (string.IsNullOrWhiteSpace(SkillRequestName))
                        {
                            result = "Skills for service cannot be empty";
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
        public DateTime RequestDate
        {
            get
            {
                if (_date == DateTime.MinValue)
                {
                    _date = DateTime.Now;
                }
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public string ServiceTime
        {
            get
            {
                return _serviceTime;
            }
            set
            {
                _serviceTime = value;
                OnPropertyChanged("ServiceTime");
            }
        }

        public string SkillRequestName
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

        public int RatingRequest
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

        public Skills AllSkills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
            }
        }

        public Contractors AllContractors
        {
            get
            {
                return _contractors;
            }
            set
            {
                _contractors = value;
            }
        }

        public TimeSlots AllTimeSlots
        {
            get
            {
                return _timeSlots;
            }
            set
            {
                _timeSlots = value;
            }
        }

        /// <summary>
        /// Collects the data for a service request
        /// </summary>
        public ServiceRequest()
        {
            AllSkills = new Skills();
            AllContractors = new Contractors();
            AllTimeSlots = new TimeSlots();
        }

    }
}
