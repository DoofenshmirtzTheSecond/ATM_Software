using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Configuration.Internal;
using System.Security.Cryptography.X509Certificates;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for Inactive_State.xaml
    /// </summary>
    public partial class Inactive_State : Page
    {
        public static string[] PIReel = new string[100];
        public static int Count { get; set; }
        public static int MaxCount { get; set; }
        public Inactive_State()
        {
            InitializeComponent();
            Count = 0;
            MaxCount = MaxCount.GiveCount();
            PIReel = PIReel.Paths();
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(3);
            Timer.Tick += dispatcherTimer_Tick;
            Timer.Start();
            PIBtn.Focus();
        }
        private void CardEntered(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                PIBtn.PerformClick();
            }
        }
        private void MoveToMainPage(object sender, EventArgs e)
        {
            LanguageChoice languageChoice = new LanguageChoice();
            this.NavigationService.Navigate(languageChoice);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Count == MaxCount)
            {
                Count = 0;
                var uri = new System.Uri(PIReel[Count]);
                ImageSource imgSource = new BitmapImage(uri);
                PI.Source = imgSource;
                Count++;
            }
            else
            {
                var uri = new System.Uri(PIReel[Count]);
                ImageSource imgSource = new BitmapImage(uri);
                PI.Source = imgSource;
                Count++;
            }
            
            
        }
    }

}

