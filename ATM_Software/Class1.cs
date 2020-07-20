using ATM_Software;
using System;
using System.IO;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Security.Cryptography;

namespace System.Windows.Controls
{
    public static class InputHandler
    {
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
        public static void TextBoxControl(this TextBox Digit1, TextBox Digit2, TextBox Digit3, TextBox Digit4, KeyEventArgs e)
        {
            if (Digit1.Text.Length == Digit1.MaxLength)
            {
                Digit2.Focus();
            }
            if (Digit2.Text.Length == Digit2.MaxLength)
            {
                Digit3.Focus();
            }
            if (Digit3.Text.Length == Digit3.MaxLength)
            {
                Digit4.Focus();
            }
            if ((Digit2.IsFocused) && (e.Key == Key.Back) && (Digit2.Text.Length == 0))
            {
                Digit1.Focus();
            }
            if ((Digit3.IsFocused) && (e.Key == Key.Back) && (Digit3.Text.Length == 0))
            {
                Digit2.Focus();
            }
            if ((Digit4.IsFocused) && (e.Key == Key.Back) && (Digit4.Text.Length == 0))
            {
                Digit3.Focus();
            }
        }

        public static int ConfirmPinValidator(this TextBox Digit1, TextBox Digit2, TextBox Digit3, TextBox Digit4, TextBox Digit1Conf, TextBox Digit2Conf, TextBox Digit3Conf, TextBox Digit4Conf)
        {
            if((Digit1.Text == Digit1Conf.Text) && (Digit2.Text == Digit2Conf.Text) && (Digit3.Text == Digit3Conf.Text) && (Digit4.Text == Digit4Conf.Text))
            {
                return (1);
            }
            else
            {
                return (0);
            }
        }

        public static int PinFieldValidator(this TextBox Digit1, TextBox Digit2, TextBox Digit3, TextBox Digit4)
        {
            if ((Digit1.Text.Length + Digit2.Text.Length + Digit3.Text.Length + Digit4.Text.Length) == (Digit1.MaxLength + Digit2.MaxLength + Digit3.MaxLength + Digit4.MaxLength))
            {
                return (1);
            }
            else
            {
                return (0);
            }
        }
    }

    public static class HandleNavigation
    {
        private static string Temp { get; set; }
        private static string Navigatedpath { get; set; }

        private static void HandleNavigationPath()
        {
            Navigatedpath += "+" + Temp;
        }

        private static void EndTransaction()
        {
            Temp = "";
            Navigatedpath = "";
        }
        public static void Navigation(this Page Source, Object Destination, Button Choice)
        {
            Temp += Choice.Name;
            HandleNavigationPath();
            Temp = "";
            Source.NavigationService.Navigate(Destination);
        }
        public static void Navigation(this Page Source, Button Choice)
        {
            Temp += Choice.Name;
            if (Navigatedpath == "+Withdrawal")
            {
                HandleNavigationPath();
                EnterAmount enterAmount = new EnterAmount();
                Temp = "";
                Source.NavigationService.Navigate(enterAmount);
            }
            else
            {
                HandleNavigationPath();
                EnterPin enterPin = new EnterPin();
                Temp = "";
                Source.NavigationService.Navigate(enterPin);
            }
        }
        public static void Navigation(this Page Cancelled)
        {
            EndTransaction();
            Inactive_State inactive_State = new Inactive_State();
            Cancelled.NavigationService.Navigate(inactive_State);
        }
    }
}

