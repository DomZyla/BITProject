using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    class AddNewCoordinatorViewModel
    {
        
        /// <summary>
        /// Private properties
        /// </summary>
        private Coordinator _coordinator;
        private RelayCommand _addCommand;

        /// <summary>
        /// Public Properties
        /// </summary>  
        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(AddMethod, true);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
            }
        }

        public AddNewCoordinatorViewModel()
        {
            _coordinator = new Coordinator();
        }

        public Coordinator Coordinator
        {
            get
            {
                return _coordinator;
            }
            set
            {
                _coordinator = value;
            }
        }

        /// <summary>
        /// Add Method for inserting a Coordinator
        /// </summary>
        public void AddMethod()
        {
            Coordinator.InsertCoordinator();
            MessageBox.Show("Coordinator inserted successfully");
        }
    }
}
