using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    public class AddNewContractorViewModel
    {

        /// <summary>
        /// Private properties
        /// </summary>
        private Contractor _contractor;
        private RelayCommand _addCommand;

        /// <summary>
        /// Public properties
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

        public AddNewContractorViewModel()
        {
            _contractor = new Contractor();
        }

        public Contractor Contractor
        {
            get
            {
                return _contractor;
            }
            set
            {
                _contractor = value;
            }
        }

        /// <summary>
        /// Method for adding a new contractor
        /// </summary>
        public void AddMethod()
        {
            Contractor.InsertContractor();
            MessageBox.Show("Contractor inserted successfully");
        }
    }
}
