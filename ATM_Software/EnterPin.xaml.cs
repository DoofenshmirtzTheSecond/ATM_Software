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
using System.Configuration;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for EnterPin.xaml
    /// </summary>
    public partial class EnterPin : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound;
        public static string Digit11 { get; set; }
        public static string Digit22 { get; set; }
        public static string Digit33 { get; set; }
        public static string Digit44 { get; set; }
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public EnterPin()
        {
            InitializeComponent();
            HandleThemes();
            Digit1.Focus();
            SetLanguage();
        }

        public void PinPageControl(object sender, KeyEventArgs e)
        {
            Digit1.TextBoxControl(Digit2, Digit3, Digit4, e);
            if (e.Key == Key.F9)
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
            if((Digit1.Text == Digit11)&&(Digit2.Text==Digit22)&&(Digit3.Text==Digit33)&&(Digit4.Text==Digit44))
            {
                Final final = new Final();
                this.NavigationService.Navigate(final);
            }
            else
            {
                this.Settt();
                Final final = new Final();
                this.NavigationService.Navigate(final);
            }
        }
        private void SetLanguage()
        {
            if (this.PutLanguage() == 1)
            {
                StateInfo.Content = Resource1.Enter;
                Enter.Content = Resource1.Enter;
                ForgotPin.Content = Resource1.ForgotPin;
                Cancel.Content = Resource1.Cancel;

            }
            else
            {
                var uri = new System.Uri(Sound);
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
            }
        }
        private void HandleThemes()
        {
            PrimaryTheme = ConfigurationManager.AppSettings.Get("PrimaryTheme");
            SecondaryTheme = ConfigurationManager.AppSettings.Get("SecondaryTheme");
            CompanyLogo = ConfigurationManager.AppSettings.Get("CompanyLogo");
            Sound = ConfigurationManager.AppSettings.Get("passcode");
            Digit11 = ConfigurationManager.AppSettings.Get("Digit1");

            Digit22 = ConfigurationManager.AppSettings.Get("Digit2");

            Digit33 = ConfigurationManager.AppSettings.Get("Digit3");

            Digit44 = ConfigurationManager.AppSettings.Get("Digit4");
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
            Enter.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Enter.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Cancel.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Cancel.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            ForgotPin.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            ForgotPin.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
        }
    }
}