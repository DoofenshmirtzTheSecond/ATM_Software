using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for AccountType.xaml
    /// </summary>
    public partial class AccountType : Page
    {
        public AccountType()
        {
            InitializeComponent();
            SavingsAcc.Focus();
        }
        private void AccountTypeMenu(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.F1)
            {
                SavingsAcc.PerformClick();
            }
            if (e.Key == Key.F2)
            {
                CurrentAcc.PerformClick();
            }
            if (e.Key == Key.F3)
            {
                CreditCrd.PerformClick();
            }
            if (e.Key == Key.F9)
            {
                Cancel.PerformClick();
            }
        }
        private void ProceedTransaction(object sender, EventArgs e)
        {
            Button button = sender as Button;
            this.Navigation(button);
        }
        private void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
        }
    }
}