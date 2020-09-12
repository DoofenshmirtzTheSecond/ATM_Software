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
using System.Configuration;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for EnterAmount.xaml
    /// </summary>
    public partial class EnterAmount : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound;

        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public EnterAmount()
        {
            InitializeComponent();
            HandleThemes();
            SetLanguage();
            Amount.Focus();
        }

        public void AmountKeys(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
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
        private void SetLanguage()
        {
            if (this.PutLanguage() == 1)
            {
                Cancel.Content = Resource1.Cancel;
                Confirm.Content = Resource1.Confirm;
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
            Sound = ConfigurationManager.AppSettings.Get("amount");
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
            Rs500.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Rs500.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Rs5000.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Rs5000.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Rs1000.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Rs1000.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Rs10000.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Rs10000.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Confirm.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Confirm.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Cancel.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Cancel.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
        }
    }
}
