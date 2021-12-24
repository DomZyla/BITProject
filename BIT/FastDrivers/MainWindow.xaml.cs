using FastDrivers.ViewModel;
using FastDrivers.Views;
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

namespace FastDrivers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.DataContext = new MainWindowViewModel();
        }

        private void btnClientManagement_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new ClientManagementView();
        }

        private void btnContractorManagement_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new ContractorManagementView();
        }

        private void btnCoordinatorManagement_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new CoordinatorManagementView();
        }

        private void btnServiceManagement_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new ServiceManagementView();
        }

        private void btnSkillsManagement_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new SkillsManagementView();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }


    }
}
