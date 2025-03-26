using System;
using System.Diagnostics;
using Phasmaphobia_Editor.Core.Services;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Phasmaphobia_Editor.Views
{
    public sealed partial class testDetailsDetailControl : UserControl
    {
        // public testDetailsPage ViewModel { get; } = new testDetailsPage();

        public SampleOrder ListMenuItem
        {
            get { return GetValue(ListMenuItemProperty) as SampleOrder; }
            set { SetValue(ListMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListMenuItemProperty = DependencyProperty.Register("ListMenuItem", typeof(SampleOrder), typeof(testDetailsDetailControl), new PropertyMetadata(null, OnListMenuItemPropertyChanged));

        public testDetailsDetailControl()
        {
            InitializeComponent();

        }

        private static void OnListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as testDetailsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

        private void ForegroundElement_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }

        private void ForegroundElement_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ForegroundElement_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {

        }
    }
}
