using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    public class AddServiceViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private Client _selectedClient;

        private ObservableCollection<Service> _sessions;

        private ServiceRequest _request;

        private Service _selectedSession;

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
        public ObservableCollection<Service> Sessions
        {
            get
            {
                return _sessions;
            }
            set
            {
                _sessions = value;
                OnPropertyChanged("Sessions");
            }
        }
            
        public Service SelectedSession
        {
            get
            {
                return _selectedSession; 
            }
            set
            {
                _selectedSession = value;
            }
        }


        private RelayCommand _findCommand;

        public RelayCommand FindCommand
        {
            get
            {
                if (_findCommand == null)
                {
                    _findCommand = new RelayCommand(FindMethod, true);
                }
                return _findCommand;
            }
            set
            {
                _findCommand = value;
            }

        }

        private RelayCommand _confirmCommand;

        public RelayCommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand(ConfirmMethod, true);
                }
                return _confirmCommand;
            }
            set
            {
                _confirmCommand = value;
            }

        }

        /// <summary>
        /// Method for finding services with inserted data
        /// </summary>
        public void FindMethod()
        {
            Services services = new Services(Request);

            Sessions = new ObservableCollection<Service>(services);
        }

        public Client SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
            }
        }

        public ServiceRequest Request
        {
            get
            {
                return _request;
            }
            set
            {
                _request = value;
            }
        }

        /// <summary>
        /// Parses Client as selected client and creates a new Request using ServiceRequest class
        /// </summary>
        /// <param name="client"></param>
        public AddServiceViewModel(Client client)
        {
            SelectedClient = client;
            Request = new ServiceRequest();
        }

        /// <summary>
        /// Method for assigning a job to a contractor
        /// </summary>
        public void ConfirmMethod()
        {
            if(SelectedSession!=null)
            {
                SQLHelper _db = new SQLHelper();

                string sql = "Set Identity_Insert Job_Hour_Log ON " +
                    "declare @JobRequest_Id int " +
                    "insert into Job_Request (Location_ref, Skill_Id_Ref, Contractor_Id_Ref, RequestDate, RequestStatus, Kilometers) " +
                    "Values (" + SelectedClient.ClientId + " , " + SelectedSession.SkillId + " , " + SelectedSession.ContractorId + " , '" + Request.RequestDate + "' , 'Pending' , 0 )" +
                    "set @JobRequest_Id = SCOPE_IDENTITY() " +
                    "insert into Job_Hour_Log (JobRequest_Ref, Date, StartTime, EndTime) " +
                    "values (@JobRequest_Id, '" + Request.RequestDate + "','" + Request.ServiceTime + "', '18:00:00')";

                int rowsAffected = _db.ExecuteNonQuery(sql);

                if(rowsAffected > 0)
                {
                    MessageBox.Show("Service successfully created!");
                }
            }
            else
            {
                MessageBox.Show("Please select an available Contractor.");
            }
        }

    }
}
