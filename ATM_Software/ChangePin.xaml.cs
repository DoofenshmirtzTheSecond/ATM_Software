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
using System.Configuration;
using System.Resources;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for ChangePin.xaml
    /// </summary>
    public partial class ChangePin : Page
    {
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public ChangePin()
        {

            InitializeComponent();
            HandleThemes();
            SetLanguage();
            Handle = 0;
            Digit1.Focus();
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
        {
            if ((Digit1.PinFieldValidator(Digit2, Digit3, Digit4) != 1) || (Handle == 0))
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
                        StateInfo.Content = "Enter All Four Digits";
                    }
                }
            }
            else
            {
                Digit1Conf.Focus();
                Digit1Conf.TextBoxControl(Digit2Conf, Digit3Conf, Digit4Conf, e);
                if (e.Key == Key.F9)
                {
                    if ((Digit1Conf.PinFieldValidator(Digit2Conf, Digit3Conf, Digit4Conf) == 1) && (Digit1.ConfirmPinValidator(Digit2, Digit3, Digit4, Digit1Conf, Digit2Conf, Digit3Conf, Digit4Conf) == 1))
                    {
                        Confirm.PerformClick();
                    }
                    else if ((Digit1Conf.PinFieldValidator(Digit2Conf, Digit3Conf, Digit4Conf) == 1))
                    {
                        StateInfo.Content = "PINS DON'T Match";
                    }
                    else
                    {
                        StateInfo.Content = "Enter all four Digits";
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
            SetSetting("Digit1", Digit1.Text);
            SetSetting("Digit2", Digit2.Text);
            SetSetting("Digit3", Digit3.Text);
            SetSetting("Digit4", Digit4.Text);
            this.Setpc();
            Final final = new Final();
            this.NavigationService.Navigate(final);
        }

        public void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
        }
        private void SetLanguage()
        {
            if (this.PutLanguage() == 1)
            {
                Confirm.Content = Resource1.Confirm;
                Cancel.Content = Resource1.Cancel;

            }
        }
        private void HandleThemes()
        {
            PrimaryTheme = ConfigurationManager.AppSettings.Get("PrimaryTheme");
            SecondaryTheme = ConfigurationManager.AppSettings.Get("SecondaryTheme");
            CompanyLogo = ConfigurationManager.AppSettings.Get("CompanyLogo");
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
            Confirm.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Confirm.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Cancel.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Cancel.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
        }
        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

