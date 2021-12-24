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
    /// Interaction logic for ContractorManagementView.xaml
    /// </summary>
    public partial class ContractorManagementView : Page
    {
        public ContractorManagementView()
        {
            InitializeComponent();
            this.DataContext = new ContractorManagementViewModel();
        }

        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {

            Contractor selectedContractor = (Contractor)dgContractors.SelectedItem;

            if (selectedContractor != null)
            {
                //this.NavigationService.Navigate(new Uri("Views/AddServiceView.xaml", UriKind.Relative));
                this.NavigationService.Navigate(new AddSkillView(selectedContractor));
            }
            else
            {
                MessageBox.Show("Please select contractor first before adding a Skill");
            }
        }

        private void btnAddNewContractor_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/AddContractorView.xaml", UriKind.Relative));
        }
        
    }
}
