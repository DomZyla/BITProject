using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private string _userName;
        private string _password;
        private string _showLogin;
        private string _showMenu;
        private string _showCoordinator;
        private SQLHelper _db;

        private RelayCommand _loginCommand;

        /// <summary>
        /// Public Properties
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(LoginMethod, true);
                }
                return _loginCommand;
            }
            set
            {
                _loginCommand = value;
            }

        }

        /// <summary>
        /// Method for loging into the system which is either for Coordinators or Admin
        /// </summary>
        public void LoginMethod()
        {
            _db = new SQLHelper();
            string sql = "select * from Person as p, Contractor as c where p.Person_ID = c.Person_ID_Ref AND username ='" + _userName + "' and password='" + _password + "'";
            string sql2 = "select * from Person where Person_ID = 10 AND username ='" + _userName + "' and password='" + _password + "'";

            DataTable LoginResult = _db.ExecuteSQL(sql);

            if (LoginResult == null)
            {
                MessageBox.Show("Please enter valid username and password");
                return;
            }

            if (LoginResult.Rows.Count == 1)
            {
                ShowMenu = "Visible";
                ShowCoordinator = "Hidden";
                ShowLogin = "Hidden";
            }

            else
            {

                DataTable LoginResult2 = _db.ExecuteSQL(sql2);

                if (LoginResult2.Rows.Count == 1)
                {
                    ShowMenu = "Visible";
                    ShowCoordinator = "Visible";
                    ShowLogin = "Hidden";
                }
                else
                { 
                ShowMenu = "Hidden";
                ShowCoordinator = "Hidden";
                ShowLogin = "Visible";
                MessageBox.Show("Please enter valid username and password");
                }
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
        /// Public Properties
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string ShowLogin
        {
            get
            {
                if(_showLogin== "")
                {
                    return "Visible";
                }
                return _showLogin;
            }
            set
            {
                _showLogin = value;
                OnPropertyChanged("ShowLogin");
            }
        }

        public string ShowMenu
        {
            get
            {
                if (_showMenu == "")
                {
                    return "Hidden";
                }
                return _showMenu;
            }
            set
            {
                _showMenu = value;
                OnPropertyChanged("ShowMenu");
            }
        }

        public string ShowCoordinator
        {
            get
            {
                if (_showCoordinator == "")
                {
                    return "Hidden";
                }
                return _showCoordinator;
            }
            set
            {
                _showCoordinator = value;
                OnPropertyChanged("ShowCoordinator");
            }
        }

    }
}
