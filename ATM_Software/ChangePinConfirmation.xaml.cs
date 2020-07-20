using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for ChangePinConfirmation.xaml
    /// </summary>
    public partial class ChangePinConfirmation : Page
    {
        public ChangePinConfirmation()
        {
            InitializeComponent();
            Confirm.Focus();
        }
        public void ConfirmPinChange_Choice(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F9)
            {
                Confirm.PerformClick();
            }
            else if (e.Key == Key.F8)
            {
                Cancel.PerformClick();
            }

        }
    }
}
