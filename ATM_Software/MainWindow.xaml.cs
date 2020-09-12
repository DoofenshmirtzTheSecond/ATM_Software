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
using System.Configuration;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(this.IsFirstRun()==0)
            {
                SPTheme1 sPTheme1 = new SPTheme1();
                Frame.NavigationService.Navigate(sPTheme1);
            }
            else
            {
                Inactive_State inactive_State = new Inactive_State();
                Frame.NavigationService.Navigate(inactive_State);
            }
        }


    }
}
