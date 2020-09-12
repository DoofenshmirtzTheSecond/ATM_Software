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
    /// Interaction logic for LanguageChoice.xaml
    /// </summary>
    public partial class LanguageChoice : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound;
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }
        public LanguageChoice()
        {
            InitializeComponent();
            HandleThemes();
            var uri = new System.Uri(Sound);
            mediaPlayer.Open(uri);
            mediaPlayer.Play();
            English.Focus();
        }
        public void ChooseLanguage(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Hindi.PerformClick();
            }
            if (e.Key == Key.F2)
            {
                English.PerformClick();
            }
        }
        public void Clicker(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.SetLanguageChoice();
            MainPage mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }
        private void HandleThemes()
        {
            PrimaryTheme = ConfigurationManager.AppSettings.Get("PrimaryTheme");
            SecondaryTheme = ConfigurationManager.AppSettings.Get("SecondaryTheme");
            CompanyLogo = ConfigurationManager.AppSettings.Get("CompanyLogo");
            Sound = ConfigurationManager.AppSettings.Get("Welcome");
            this.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Secondary.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            English.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            English.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            Hindi.Background = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
            Hindi.Foreground = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
            var uri = new System.Uri(CompanyLogo);
            ImageSource imgSource = new BitmapImage(uri);
            Logo.Source = imgSource;
        }
    }
}
