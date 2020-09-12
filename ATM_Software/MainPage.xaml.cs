using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound;
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public MainPage()
        {
            InitializeComponent();
            HandleThemes();
            SetLanguage();
            Withdrawal.Focus();
        }
        private void MainMenu_Choice(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Withdrawal.PerformClick();
            }
            else if (e.Key == Key.F2)
            {
                Mini_Statement.PerformClick();
            }
            else if (e.Key == Key.F3)
            {
                Account_Balance.PerformClick();
            }
            else if (e.Key == Key.F4)
            {
                Change_Pin.PerformClick();
            }
            else if (e.Key == Key.F8)
            {
                Cancel.PerformClick();
            }
        }

        public void MoveToAccType(object sender, EventArgs e)
        {
            Button button = sender as Button;
            AccountType accountType = new AccountType();
            this.Navigation(accountType, button);
        }
        public void MoveToChangePinConfirm(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ChangePinConfirmation changePinConfirmation = new ChangePinConfirmation();
            this.Navigation(changePinConfirmation, button);
        }
        private void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
        }
        private void SetLanguage()
        {
            if (this.PutLanguage() == 1)
            {
                Account_Balance.Content = Resource1.Account_Balance;
                Mini_Statement.Content = Resource1.Mini_Statement;
                Change_Pin.Content = Resource1.Change_Pin;
                Withdrawal.Content = Resource1.Withdrawal;
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
            Sound = ConfigurationManager.AppSettings.Get("mpa");
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
            Mini_Statement.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Mini_Statement.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Account_Balance.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Account_Balance.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Withdrawal.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Withdrawal.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Change_Pin.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Change_Pin.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Cancel.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Cancel.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
        }
        
    }
}
