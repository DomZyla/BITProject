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
    public class ContractorManagementViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private ObservableCollection<Contractor> _contractors;

        private Contractor _selectedContractor;

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
        /// Method for updating a contractor
        /// </summary>
        public void UpdateMethod()
        {
            SelectedContractor.UpdateContractor();
            MessageBox.Show("Updated contractor details successfully");
        }

        /// <summary>
        /// Method for setting a contractor as inactive
        /// </summary>
        public void DeleteMethod()
        {
            SelectedContractor.DeleteContractor();
            MessageBox.Show("Contractor has been deleted successfully");
        }

        /// <summary>
        /// Getting contractor information for the table
        /// </summary>
        public ContractorManagementViewModel()
        {
            //Get the contractors data from the db

            Contractors = GetContractors();

        }

        /// <summary>
        /// Public Properties
        /// </summary>
        public ObservableCollection<Contractor> Contractors
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

        public Contractor SelectedContractor
        {
            get
            {
                return _selectedContractor;
            }
            set
            {
                _selectedContractor = value;
            }
        }

        public ObservableCollection<Contractor> GetContractors()
        {
            Contractors allContractors = new Contractors();

            ObservableCollection<Contractor> contractors = new ObservableCollection<Contractor>(allContractors);
            return contractors;
        }

    }
}
