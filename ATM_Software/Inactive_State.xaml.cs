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
using System.Configuration.Internal;
using System.Security.Cryptography.X509Certificates;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for Inactive_State.xaml
    /// </summary>
    public partial class Inactive_State : Page
    {
        public Inactive_State()
        {
            InitializeComponent();
            PromotionalImageryBtn.Focus();
        }
        private void CardEntered(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                PromotionalImageryBtn.PerformClick();
            }
        }
        private void MoveToMainPage(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }
    }

}

