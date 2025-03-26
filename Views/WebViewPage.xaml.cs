using System;
using System.Diagnostics;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Phasmaphobia_Editor.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Phasmaphobia_Editor.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewViewModel ViewModel { get; } = new WebViewViewModel();

        public WebViewPage()
        {
            InitializeComponent();
            //web.Navigate(new Uri(@"https://tybayn.github.io/phasmo-cheat-sheet/"));
        }

        private void web_LoadCompleted(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            //web.Navigate(new Uri(@"https://tybayn.github.io/phasmo-cheat-sheet/"));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void ContentArea_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var theme = new SettingsViewModel().ElementTheme;

            if (theme.ToString() == "Dark")
            {

                dark_banner.Visibility = Windows.UI.Xaml.Visibility.Visible;
                light_banner.Visibility = Windows.UI.Xaml.Visibility.Collapsed;


            }
            else
            {
                light_banner.Visibility = Windows.UI.Xaml.Visibility.Visible;
                dark_banner.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        string imagesource;

        private void Button_Click_4(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
