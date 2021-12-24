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
    public class CoordinatorManagementViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private ObservableCollection<Coordinator> _coordinators;

        private Coordinator _selectedCoordinator;

        private RelayCommand _updateCommand;

        private RelayCommand _deleteCommand;

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

        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(DeleteMethod, true);
                }
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
            }

        }

        /// <summary>
        /// Method for updating a coordinators details
        /// </summary>
        public void UpdateMethod()
        {
            SelectedCoordinator.UpdateCoordinator();
            MessageBox.Show("Updated Coordinator details successfully");
        }

        /// <summary>
        /// Method for setting a Coordinator as inactive
        /// </summary>
        public void DeleteMethod()
        {
            SelectedCoordinator.DeleteCoordinator();
            MessageBox.Show("Coordinator has been deleted successfully");
        }

        /// <summary>
        /// Collects all the coordinator data to display in the datagrid
        /// </summary>
        public CoordinatorManagementViewModel()
        {
            //Get the coordinators data from the db

            Coordinators = GetCoordinators();

        }

        /// <summary>
        /// Public Properties
        /// </summary>
        public ObservableCollection<Coordinator> Coordinators
        {
            get
            {
                return _coordinators;
            }
            set
            {
                _coordinators = value;
            }
        }

        public Coordinator SelectedCoordinator
        {
            get
            {
                return _selectedCoordinator;
            }
            set
            {
                _selectedCoordinator = value;
            }
        }

        public ObservableCollection<Coordinator> GetCoordinators()
        {
            Coordinators allCoordinators = new Coordinators();

            ObservableCollection<Coordinator> coordinators = new ObservableCollection<Coordinator>(allCoordinators);
            return coordinators;
        }
    }
}
