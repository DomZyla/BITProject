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
    /// Interaction logic for AddNewSkillView.xaml
    /// </summary>
    public partial class AddNewSkillView : Page
    {
        public AddNewSkillView()
        {
            InitializeComponent();
            this.DataContext = new AddNewSkillViewModel();
        }

        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
