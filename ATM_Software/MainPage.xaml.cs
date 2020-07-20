using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Withdrawal.Focus();
        }
        private void MainMenu_Choice(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Withdrawal.PerformClick();
            }
            else if (e.Key == Key.F2)
            {
                Mini_Statement.PerformClick();
            }
            else if (e.Key == Key.F3)
            {
                Account_Balance.PerformClick();
            }
            else if (e.Key == Key.F4)
            {
                Change_Pin.PerformClick();
            }
            else if (e.Key == Key.F8)
            {
                Cancel.PerformClick();
            }
        }

        public void MoveToAccType(object sender, EventArgs e)
        {
            Button button = sender as Button;
            AccountType accountType = new AccountType();
            this.Navigation(accountType, button);
        }
        public void MoveToChangePinConfirm(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ChangePinConfirmation changePinConfirmation = new ChangePinConfirmation();
            this.Navigation(changePinConfirmation, button);
        }
        private void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
        }
    }
}
