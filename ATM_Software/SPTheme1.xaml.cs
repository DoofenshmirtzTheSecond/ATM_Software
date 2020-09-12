using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Configuration;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.IO.Pipes;

namespace ATM_Software
{
    /// <summary>
    /// Interaction logic for SPTheme1.xaml
    /// </summary>
    public partial class SPTheme1 : Page
    {
        public static int handled { get; set; }
        public static int elements { get; set; }
        public static string PrimaryTheme { get; set; }
        public static string SecondaryTheme { get; set; }
        public static string CompanyLogo { get; set; }

        public static string[] PromotionalImagery = new string[100];
        public SPTheme1()
        {
            InitializeComponent();
            handled = 0;
            SP1Choice1.Focus();
        }
        public void HandleTextBox(object sender, KeyEventArgs e)
        {
            if(handled == 0)
            {
                SP1Choice1.SettingsTextBoxControl(SP1Choice2, SP1Choice3, SP1Choice4, SP1Choice5, SP1Choice6, Theme1, e);
            }
            else if (handled == 1)
            {
                SP1Choice1.SettingsTextBoxControl(SP1Choice2, SP1Choice3, SP1Choice4, SP1Choice5, SP1Choice6, Theme2, e);
            }
            if(e.Key == Key.Enter && handled == 0)
            {
                Next.PerformClick();
            }
            if (e.Key == Key.Enter && handled == 1 && (SP1Choice6.Text!=String.Empty))
            { 
                Next.PerformClick();
            }
            if (e.Key == Key.Enter && handled == 2)
            {
                Next.PerformClick();
            }
        }

        public void HandleNext(object sender, EventArgs e)
        {
            if (handled==0)
            {
                PrimaryTheme = Theme1.GiveCode();
                Theme1.Fill = (Brush)(new BrushConverter().ConvertFrom(PrimaryTheme));
                SP1Choice1.Text = string.Empty;
                SP1Choice2.Text = string.Empty;
                SP1Choice3.Text = string.Empty;
                SP1Choice4.Text = string.Empty;
                SP1Choice5.Text = string.Empty;
                SP1Choice6.Text = string.Empty;
                SP1Label.Content = "Enter Hash Code for Secondary Theme";
                SP1Choice1.Focus();
                handled += 1;
            }
            else if (handled == 1)
            {

                SecondaryTheme = Theme1.GiveCode();
                Theme2.Fill = (Brush)(new BrushConverter().ConvertFrom(SecondaryTheme));
                SP1Choice1.Text = string.Empty;
                SP1Choice2.Text = string.Empty;
                SP1Choice3.Text = string.Empty;
                SP1Choice4.Text = string.Empty;
                SP1Choice5.Text = string.Empty;
                SP1Choice6.Text = string.Empty;
                SP1Choice1.Visibility = Visibility.Hidden;
                SP1Choice2.Visibility = Visibility.Hidden;
                SP1Choice3.Visibility = Visibility.Hidden;
                SP1Choice4.Visibility = Visibility.Hidden;
                SP1Choice5.Visibility = Visibility.Hidden;
                SP1Choice6.Visibility = Visibility.Hidden;
                handled += 1;
            }
            else if(handled == 2)
            {

                SP1Label.Content = "Select Company Logo";
                Next.Content = "Browse";
                handled += 1;
            }
            else if(handled == 3)
            {
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
                openFileDlg.DefaultExt = ".jpeg";
                Nullable<bool> result = openFileDlg.ShowDialog();
                if (result == true)
                {
                    var uri = new System.Uri(openFileDlg.FileName);
                    CompanyLogo = uri.AbsoluteUri;
                    ImageSource imgSource = new BitmapImage(uri);
                    Logo.Source = imgSource;
                    Next.Content = "Next";
                    handled += 1;
                }
            }
            else if (handled == 4)
            {

                SP1Label.Content = "Select Promotional Images";
                Next.Content = "Browse";
                handled += 1;
            }

            else if (handled == 5)
            {
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
                openFileDlg.DefaultExt = ".jpeg";
                openFileDlg.Multiselect = true;
                Nullable<bool> result = openFileDlg.ShowDialog();
                if (result == true)
                {
                    PromotionalImagery = openFileDlg.FileNames;
                    elements = openFileDlg.FileNames.Length;
                    Next.Content = "Save";
                    handled += 1;
                }
            }
            else if(handled == 6)
            {
                SetSetting("PrimaryTheme", PrimaryTheme);
                SetSetting("SecondaryTheme", SecondaryTheme);
                SetSetting("CompanyLogo", CompanyLogo);
                int x = PromotionalImagery.Length;
                for (int j = 0; j < elements; j++)
                {
                    SetSetting("PromotionalImagery" + j, PromotionalImagery[j]);
                }
                SetSetting("PINum", elements.ToString());
                SetSetting("Run", "1");
                Application.Current.Shutdown();
            }
        }
        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Add(key,value);
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
