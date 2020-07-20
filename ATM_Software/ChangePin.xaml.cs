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
    /// Interaction logic for ChangePin.xaml
    /// </summary>
    public partial class ChangePin : Page
    {
        public ChangePin()
        {
            
            InitializeComponent();
            Handle = 0;
            Digit1.Focus();
            myRectangle.Fill = Brushes.AliceBlue;
        }
        public Brush FillColor
        {
            get { return this.FillColor; }
            set
            {
                this.FillColor = Brushes.AliceBlue;
            }
        }
        public int Handle { get; set; }

        public void ChangePinPageControl(object sender, KeyEventArgs e)
        {  if ((Digit1.PinFieldValidator(Digit2, Digit3, Digit4) != 1) || (Handle == 0)) 
            {  
                Digit1.TextBoxControl(Digit2, Digit3, Digit4, e);
                if (e.Key == Key.F9)
                {
                    if (Digit1.PinFieldValidator(Digit2, Digit3, Digit4) == 1)
                    {
                        Handle = 1;
                        return;
                    }
                    else
                    {
                        StateInfo.Content = "Enter All Four Digits1";
                    }
                }
            }
            else
            {
                Digit1Conf.Focus();
                Digit1Conf.TextBoxControl(Digit2Conf, Digit3Conf, Digit4Conf, e);
                if (e.Key == Key.F9)
                {
                    if((Digit1Conf.PinFieldValidator(Digit2Conf, Digit3Conf, Digit4Conf) == 1) && (Digit1.ConfirmPinValidator(Digit2, Digit3, Digit4, Digit1Conf, Digit2Conf, Digit3Conf, Digit4Conf) == 1))
                    {
                        Confirm.PerformClick();
                    }
                    else if((Digit1Conf.PinFieldValidator(Digit2Conf, Digit3Conf, Digit4Conf) == 1))
                    {
                        StateInfo.Content = "PINS DON'T Match";
                    }
                    else
                    {
                        StateInfo.Content = "Enter all four digits2";
                    }
                }
                if ((e.Key == Key.Back) && (Digit1Conf.IsFocused) && (Digit1Conf.Text.Length == 0))
                {
                    Handle = 0;
                    ChangePinPageControl(sender, e);
                }
            }
            
        }
        public void PinChange(object sender, EventArgs e)
        {

        }

        public void CancelClick(object sender, EventArgs e)
        {

        }
        /*public Brush Backgroundd
        {
            ChangePin changePin = new ChangePin();
            SolidColorBrush BG = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
            return BG;
        }*/
    }
}
