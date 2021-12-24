using FastDrivers.Models;
using FastDrivers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastDrivers.Views
{
    /// <summary>
    /// Interaction logic for ClientManagementView.xaml
    /// </summary>
    public partial class ClientManagementView : Page
    {
        public ClientManagementView()
        {
            InitializeComponent();
            this.DataContext = new ClientManagementViewModel();
        }

        private void btnAddNewService_Click(object sender, RoutedEventArgs e)
        {

            Client selectedClient = (Client)dgClients.SelectedItem;

            if (selectedClient != null)
            {
                //this.NavigationService.Navigate(new Uri("Views/AddServiceView.xaml", UriKind.Relative));
                this.NavigationService.Navigate(new AddServiceView(selectedClient));
            }
            else
            {
                MessageBox.Show("Please select client first before adding a Service");
            }
        }

        private void btnAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/AddClientView.xaml", UriKind.Relative));
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
