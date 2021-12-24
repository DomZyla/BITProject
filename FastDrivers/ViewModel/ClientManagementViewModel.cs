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
    public class ClientManagementViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private ObservableCollection<Client> _clients;

        private Client _selectedClient;

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
        /// Method for updating a clients information
        /// </summary>
        public void UpdateMethod()
        {
            SelectedClient.UpdateClient();
            MessageBox.Show("Updated skill details successfully");
        }

        /// <summary>
        /// Method for removing a client from the table (inactive)
        /// </summary>
        public void DeleteMethod()
        {
            SelectedClient.DeleteClient();
            MessageBox.Show("Client has been deleted successfully");
        }

        /// <summary>
        /// Getting the client information for the table
        /// </summary>
        public ClientManagementViewModel()
        {
            //Get the clients data from the db

            Clients = GetClients();

        }

        /// <summary>
        /// Public Properties
        /// </summary>
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
            }
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

        public ObservableCollection<Client> GetClients()
        {
            Clients allClients = new Clients();

            ObservableCollection<Client> clients = new ObservableCollection<Client>(allClients);
            return clients;
        }
    }
}
