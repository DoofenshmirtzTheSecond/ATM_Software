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
    /// Interaction logic for Final.xaml
    /// </summary>
    public partial class Final : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public static string Sound1;
        public static string Sound2;
        public static string Sound3;
        public static string Sound4;
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo
        {
            get; set;
        }
        public Final()
        {
            InitializeComponent();
            HandleThemes();
            butt.Focus();
            int i;
            int w;
            int tt;
            int check = 2;
            check = this.PutLanguage();
            tt = this.givett();
            w = this.giveISW();
            i= this.givepc();
            var uri = new System.Uri(Sound1);
            var urii = new System.Uri(Sound2);
            var uriii = new System.Uri(Sound3);
            var uriiii = new System.Uri(Sound3);
            if (i==1)
            {  
                if(check == 1)
                {
                    label.Content = "पासवर्ड सफलतापूर्वक बदला गया";
                    labe2.Content = "अपने कार्ड को हटा दें और पुनः दर्ज करें";
                }
                else
                {
                    label.Content = "Password changed successfully.";
                    labe2.Content = "Please remove and re-enter your card!";
                }
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
            }
            if(w==1)
            {
                label.Content = "Transaction Successful!";
                labe2.Content = "Please collect your cash.";
                mediaPlayer.Open(urii);
                mediaPlayer.Play();
            }
            if (tt == 1)
            {
                label.Content = "Transaction Terminated!";
                mediaPlayer.Open(uriiii);
                mediaPlayer.Play();
            }
            else if (w==0 && i==0 && tt==0 )
            {
                label.Content = "Please Collect the receipt containing information";
                mediaPlayer.Open(uriii);
                mediaPlayer.Play();
            }
        }
        private void kd(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                butt.PerformClick();
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
            Sound1 = ConfigurationManager.AppSettings.Get("pc");
            Sound2 = ConfigurationManager.AppSettings.Get("with");
            Sound3 = ConfigurationManager.AppSettings.Get("else");
            Sound4 = ConfigurationManager.AppSettings.Get("tta");
        }
        private void forbutt(object sender, EventArgs e)
        {
            this.Navigation();
        }
    }
}
