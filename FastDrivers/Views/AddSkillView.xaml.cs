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
    /// Interaction logic for AddSkillView.xaml
    /// </summary>
    public partial class AddSkillView : Page
    {
        public AddSkillView(Contractor contractor)
        {
            InitializeComponent();
            this.DataContext = new AddSkillViewModel(contractor);
        }

        //public AddSkillView()
        //{

        //}
    }
}
