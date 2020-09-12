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
using System.Configuration;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for AccountType.xaml
    /// </summary>
    public partial class AccountType : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound;
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public AccountType()
        {
            InitializeComponent();
            HandleThemes();
            SetLanguage();
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
        private void SetLanguage()
        {
            if (this.PutLanguage() == 1)
            {

                Cancel.Content = Resource1.Cancel;
                SavingsAcc.Content = Resource1.SavingsAcc;
                CurrentAcc.Content = Resource1.SavingsAcc;
                CreditCrd.Content = Resource1.CreditCrd;

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
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
            Cancel.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Cancel.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            CreditCrd.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            CreditCrd.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            CurrentAcc.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            CurrentAcc.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            SavingsAcc.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            SavingsAcc.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Sound = ConfigurationManager.AppSettings.Get("at");
        }
    }
}