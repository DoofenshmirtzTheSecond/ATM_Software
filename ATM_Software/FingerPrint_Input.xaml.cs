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
using System.Windows.Threading;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for FingerPrint_Input.xaml
    /// </summary>
    public partial class FingerPrint_Input : Page
    {
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public static string FPRR { get; set; }
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound1;
        public static string Sound2;
        public static string Sound3;
        public static string Sound;
        public FingerPrint_Input()
        {
            InitializeComponent();
            HandleThemes();
            SetLanguage();
            FPRB.Focus();
        }
        private void HandleFP(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                StateInfo.Content = "Scanning";
                var uri = new System.Uri(Sound3);
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    var uri = new System.Uri(Sound1);
                    mediaPlayer.Open(uri);
                    mediaPlayer.Play();
                    var timerr = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
                    timerr.Start();
                    timerr.Tick += (sender, args) =>
                    {
                        timerr.Stop();
                        ChangePin changePin = new ChangePin();
                        this.NavigationService.Navigate(changePin);
                    };
                };
            }
            if (e.Key == Key.D)
            {
                StateInfo.Content = "Scanning";
                var uri = new System.Uri(Sound3);
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    var uri = new System.Uri(Sound2);
                    mediaPlayer.Open(uri);
                    mediaPlayer.Play();
                };
            }
            if (e.Key == Key.F8)
            {
                Cancel.PerformClick();

            }
        }
        private void HandleThemes()
        {
            PrimaryTheme = ConfigurationManager.AppSettings.Get("PrimaryTheme");
            SecondaryTheme = ConfigurationManager.AppSettings.Get("SecondaryTheme");
            CompanyLogo = ConfigurationManager.AppSettings.Get("CompanyLogo");
            FPRR = ConfigurationManager.AppSettings.Get("A");
            Sound1 = ConfigurationManager.AppSettings.Get("ms");
            Sound2 = ConfigurationManager.AppSettings.Get("mns");
            Sound3 = ConfigurationManager.AppSettings.Get("scan");
            Sound = ConfigurationManager.AppSettings.Get("fs");
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
            FPRB.Background = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var urii = new System.Uri(FPRR);
            ImageSource imgSourcee = new BitmapImage(urii);
            FPR.Source = imgSourcee;
            Cancel.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Cancel.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
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
            }
            else
            {
                var uri = new System.Uri(Sound);
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
            }
        }
    }
}
