using System;
using System.Collections.Generic;
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
    /// Interaction logic for EnterAmount.xaml
    /// </summary>
    public partial class EnterAmount : Page
    {
        public EnterAmount()
        {
            InitializeComponent();
            Amount.Focus();
        }

        public void AmountKeys(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {
                Rs500.PerformClick();
            }
            if (e.Key == Key.F1)
            {
                Rs1000.PerformClick();
            }
            if (e.Key == Key.F1)
            {
                Rs5000.PerformClick();
            }
            if (e.Key == Key.F1)
            {
                Rs10000.PerformClick();
            }
            if (e.Key == Key.F1)
            {
                Confirm.PerformClick();
            }
            if (e.Key == Key.F1)
            {
                Cancel.PerformClick();
            }
        }

        public void HandleAmountKey(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Amount.Text = button.Tag.ToString();
            Amount.Focus();
            Amount.Select(Amount.Text.Length, 0);
        }

        public void ConfirmAmount(object sender, EventArgs e)
        {
            Button button = sender as Button;
            EnterPin enterPin = new EnterPin();
            this.Navigation(enterPin, button);
        }
        public void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
        }
    }
}
