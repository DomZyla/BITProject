using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    public class JobManagementViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private ObservableCollection<AvailableJob> _availableJobs;

        private AvailableJob _selectedAvailableJob;

        private RelayCommand _updateCommand;

        /// <summary>
        /// Public Properties
        /// </summary>
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(UpdateMethod, true);
                }
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }

        }

        /// <summary>
        /// Test Method for updating Job data
        /// </summary>
        /// <param name="km"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateMethodTest(int km,int id)
        {
            //string sql = "Update Job_Request set RequestStatus = '" + SelectedAvailableJob.RequestStatus + "' , " +
            //    "Kilometers = " + SelectedAvailableJob.Kilometers + " WHERE JobRequest_Id = " + SelectedAvailableJob.JobRequestId

            string sql = "Update Job_Request set " +
                "Kilometers = " + km + " WHERE JobRequest_Id = " +id;
            SQLHelper _db = new SQLHelper();

            return _db.ExecuteNonQuery(sql);

        }

        /// <summary>
        /// Method for updating job data
        /// </summary>
        public void UpdateMethod()
        {
            string sql = "Update Job_Request set RequestStatus = '" + SelectedAvailableJob.RequestStatus + "' , " +
                "Kilometers = " + SelectedAvailableJob.Kilometers + " WHERE JobRequest_Id = " + SelectedAvailableJob.JobRequestId;
            SQLHelper _db = new SQLHelper();

            _db.ExecuteNonQuery(sql);
            
            MessageBox.Show("Updated skill details successfully");
        }

        /// <summary>
        /// Gets all job data for datagrid
        /// </summary>
        public JobManagementViewModel()
        {
            //Get the availableJobs data from the db

            AvailableJobs = GetAvailableJobs();

        }

        /// <summary>
        /// Public properties
        /// </summary>
        public ObservableCollection<AvailableJob> AvailableJobs
        {
            get
            {
                return _availableJobs;
            }
            set
            {
                _availableJobs = value;
            }
        }

        public AvailableJob SelectedAvailableJob
        {
            get
            {
                return _selectedAvailableJob;
            }
            set
            {
                _selectedAvailableJob = value;
            }
        }

        public ObservableCollection<AvailableJob> GetAvailableJobs()
        {
            AvailableJobs allAvailableJobs = new AvailableJobs();

            ObservableCollection<AvailableJob> availableJobs = new ObservableCollection<AvailableJob>(allAvailableJobs);
            return availableJobs;
        }

        /// <summary>
        /// List for status dropdown
        /// </summary>
        public List<string> SRequestStatus
        {
            get
            {
                return new List<string>
                {
                    "Approved",
                    "Rejected",
                    "Completed",
                    "Pending",
                    "Cancelled",
                    "Verified",
                    "Send for payment"
                };
            }
        }


    }
}
