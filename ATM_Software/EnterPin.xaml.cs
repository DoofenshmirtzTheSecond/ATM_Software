using Microsoft.Win32;
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
    /// Interaction logic for EnterPin.xaml
    /// </summary>
    public partial class EnterPin : Page
    {
        public EnterPin()
        {
            InitializeComponent();
            Digit1.Focus();
        }

        public void PinPageControl(object sender, KeyEventArgs e)
        {
            Digit1.TextBoxControl(Digit2, Digit3, Digit4, e);
            if(e.Key == Key.F9)
            {
                if ((Digit1.PinFieldValidator(Digit2, Digit3, Digit4) == 1))
                {
                    Enter.PerformClick();
                }
                else
                {
                    StateInfo.Content = "Enter All Four Digits Of Your Pin";
                }
            }
            else if (e.Key == Key.F8)
            {
                Cancel.PerformClick();
            }
        }
        private void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
        }
        public void ProcessTransaction(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ChangePin changePin = new ChangePin();
            this.Navigation(changePin,button);
        }
    }
}
