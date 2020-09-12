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
using System.Windows.Media;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Configuration;

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
            if ((Digit1.Text == Digit1Conf.Text) && (Digit2.Text == Digit2Conf.Text) && (Digit3.Text == Digit3Conf.Text) && (Digit4.Text == Digit4Conf.Text))
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
        private static int tt { get; set; }
        private static int isw { get; set; }
        private static int pcc { get; set; }
        private static string Temp { get; set; }
        private static string Navigatedpath { get; set; }

        public static void setISW(this Page page)
        {
            isw = 1;
        }
        public static void Setpc(this Page page)
        {
            pcc = 1;
        }
        public static int giveISW(this Page page)
        {
            return isw;
        }
        public static int givepc(this Page page)
        {
            return pcc;
        }
        public static void Settt(this Page page)
        {
            tt = 1;
        }
        public static int givett(this Page page)
        {
            return tt;
        }
        private static void HandleNavigationPath()
        {
            Navigatedpath += "+" + Temp;
        }

        private static void EndTransaction()
        {
            Temp = "";
            Navigatedpath = "";
            isw = 0;
            pcc = 0;
        }
        public static void EndTransaction(this Page page)
        {
            Temp = "";
            Navigatedpath = "";
            isw = 0;
            pcc = 0;
            tt = 0;
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
                isw = 1;
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
    public static class HandleAccessibility
    {
        
        public static int LanguageChoice { get; set; } 
        public static void SetLanguageChoice (this Button Language)
        {
            if (Language.Name == "Hindi")
            {
                LanguageChoice = 1;
            }
            else
                LanguageChoice = 2;
        }
        public static int PutLanguage(this Page page)
        {
            return LanguageChoice;
        }
    }
    public static class HandleThemes
    {
        public static int IsFirstRun(this Window window)
        {
            if(ConfigurationManager.AppSettings["Run"]==null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static string Codes { get; set; }
        public static void SettingsTextBoxControl(this TextBox Digit1, TextBox Digit2, TextBox Digit3, TextBox Digit4, TextBox Digit5, TextBox Digit6, Rectangle Theme, KeyEventArgs e)
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
            if (Digit4.Text.Length == Digit4.MaxLength)
            {
                Digit5.Focus();
            }
            if (Digit5.Text.Length == Digit5.MaxLength)
            {
                Digit6.Focus();
                if (e.Key != Key.Back)
                {
                    string c = e.Key.ToString();
                    string handledc = c.HandleC();
                    Digit6.Text = handledc;
                    Digit6.SelectionStart = Digit6.Text.Length;
                    Digit6.SelectionLength = 0;
                }
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
            if ((Digit5.IsFocused) && (e.Key == Key.Back) && (Digit5.Text.Length == 0))
            {
                Digit4.Focus();
            }
            
            if ((Digit6.IsFocused) && (e.Key == Key.Back) && (Digit6.Text.Length == 0))
            {
                Digit5.Focus();
            }
            if ((Digit6.IsFocused) && (Digit6.Text.Length != 0))
            {
                string actual = ("#" + Digit1.Text + Digit2.Text + Digit3.Text + Digit4.Text + Digit5.Text + Digit6.Text);
                Theme.FillColor(actual);
            }
        }
        public static string HandleC(this String c)
        {
            if(c.Length==2)
            {
                char MyChar = 'D' ;
                string handledc = c.TrimStart(MyChar);
                return handledc;
            }
            else
            {
                return c;
            }
        }
        public static void FillColor(this Rectangle rectangle, String actual)
        {
            Regex regex = new Regex("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
            rectangle.Fill = Brushes.Black;
            if (regex.IsMatch(actual))
            {
                rectangle.Fill = (Brush)(new BrushConverter().ConvertFrom(actual));
                Codes = actual;
            }
        }
        public static string GiveCode(this Rectangle rectangle)
        {
            return Codes;
        }
    }
    public static class PromotionalReel
    {
        public static int GiveCount (this int Count )
        {
            Count= Int32.Parse(ConfigurationManager.AppSettings.Get("PINum"));
            return Count;
        }
        public static string[] PIReel = new string[100];
        public static string[] Paths(this string[] LOP)
        {
            string elements;
            elements = ConfigurationManager.AppSettings.Get("PINum");
            int n = Int32.Parse(elements);
            for (int i=0;i<n;i++)
            {
                PIReel[i] = ConfigurationManager.AppSettings.Get("PromotionalImagery" + i);
                LOP[i] = ConfigurationManager.AppSettings.Get("PromotionalImagery" + i);
            }
            return LOP;
        }
    }
}

