using System;
using System.Diagnostics;
using Phasmaphobia_Editor.ViewModels;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace Phasmaphobia_Editor.Views
{
    // TODO: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
            shellFrame.Navigate(typeof(testDetailsPage));
            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(1900, 1900);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500,500));

            navigationView.SelectedItem = navigationView.MenuItems[2];
        }

        public ContentDialog savestats { get; set; }

        private void Test_Click()
        {
            Debug.WriteLine("test");
        }

        private void shellFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            
        }

        string targetTab;
        
        private void SaveBtn_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {

            Debug.WriteLine(navigationView.SelectedItem);
            //new BlankPage().EnumSaveAsync();
        }

        //private void NavigationViewItem_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        //{
        // //   ShellPage shell = new ShellPage();
            
        //}

        //private void navigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        //{
        //    if (args.IsSettingsSelected)
        //    {

        //    }
        //    else
        //    {
        //        NavigationViewItem item = args.SelectedItem as NavigationViewItem;

        //        switch (item.Tag.ToString())
        //        {
        //            case "Edit":
        //                shellFrame.Navigate(typeof(BlankPage));
        //                break;
        //        }
        //    }
        //}

        //private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        ////    shellFrame.Navigate(typeof(BlankPage));

        //}

        //private void navigationView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    shellFrame.Navigate(typeof(BlankPage));
        //}
    }
}
