﻿using System;

using Phasmaphobia_Editor.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace Phasmaphobia_Editor
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }



        public App()
        {
           // ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(500, 500));
            InitializeComponent();
            UnhandledException += OnAppUnhandledException;
            
            // Deferred execution until used. Check https://docs.microsoft.com/dotnet/api/system.lazy-1 for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // TODO: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.BlankPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
