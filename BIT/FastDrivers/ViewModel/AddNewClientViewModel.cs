using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    public class AddNewClientViewModel
    {
        
        /// <summary>
        /// Private properties
        /// </summary>
        private Client _client;
        private RelayCommand _addCommand;

        /// <summary>
        /// public properties
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

        public AddNewClientViewModel()
        {
            _client = new Client();
        }

        public Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        /// <summary>
        /// Add method for a new client
        /// </summary>
        public void AddMethod()
        {
            Client.InsertClient();
            MessageBox.Show("Client inserted successfully");
        }
    }
}
