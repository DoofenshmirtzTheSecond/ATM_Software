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
using System.Runtime.InteropServices;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for ChangePinConfirmation.xaml
    /// </summary>
    public partial class ChangePinConfirmation : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound;
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public ChangePinConfirmation()
        {
            InitializeComponent();
            HandleThemes();
            SetLanguage();
            Confirm.Focus();
        }
        public void ConfirmPinChange_Choice(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F9)
            {
                Confirm.PerformClick();
            }
            else if (e.Key == Key.F8)
            {
                Cancel.PerformClick();
            }

        }
        private void SetLanguage()
        {
            if (this.PutLanguage() == 1)
            {
                Confirm.Content = Resource1.Confirm;
                Cancel.Content = Resource1.Cancel;
            }
            else
            {
                var uri = new System.Uri(Sound);
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
            }
        }
        private void ConfirmClick(object sender, EventArgs e)
        {
            FingerPrint_Input fingerPrint_Input = new FingerPrint_Input();
            this.NavigationService.Navigate(fingerPrint_Input);
        }
        private void CancelClick(object sender, EventArgs e)
        {
            this.Navigation();
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
            Sound = ConfigurationManager.AppSettings.Get("ct");
        }

    }
}
