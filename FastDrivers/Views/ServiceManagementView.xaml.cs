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
    /// Interaction logic for ServiceManagementView.xaml
    /// </summary>
    public partial class ServiceManagementView : Page
    {
        public ServiceManagementView()
        {
            InitializeComponent();
            this.DataContext = new JobManagementViewModel();
        }

        private void btnSubmitFeedback_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Feedback Has Been Submitted");
        }
    }
}
