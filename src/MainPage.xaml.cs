﻿using MediaBrowser.Apps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace MediaBrowser
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FirstLoad();
        }

        public void FirstLoad()
        {
            bool load = true;
            if (load == true)
            {
                mediaElement.Source = new Uri("ms-appx:///Sounds/windows-media-center-startup.wav");
                mediaElement.Play();
            }
            load = false;
        }

        // Top
        private void buttonWindow_Click(object sender, RoutedEventArgs e)
        {
            var currentSize = ApplicationView.GetForCurrentView();
            if (!currentSize.IsFullScreenMode)
            {
                currentSize.TryEnterFullScreenMode();
            }
            else
            {
                currentSize.ExitFullScreenMode();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {

        }

        // Center
        // Tasks
        private async void buttonShutdown_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.ShutdownDialog shutdownDialog = new Dialogs.ShutdownDialog();
            await shutdownDialog.ShowAsync();
        }

        private async void buttonReboot_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.RebootDialog rebootDialog = new Dialogs.RebootDialog();
            await rebootDialog.ShowAsync();
        }

        private async void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.AboutDialog aboutDialog = new Dialogs.AboutDialog();
            await aboutDialog.ShowAsync();
        }

        // Picture
        private void myPicturesButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PicturePage), null, new DrillInNavigationTransitionInfo());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CameraPage), null, new DrillInNavigationTransitionInfo());
        }

        // Music
        private void myMusicButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MusicPage), null, new DrillInNavigationTransitionInfo());
        }

        // Videos
        private void myVideosButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VideosPage), null, new DrillInNavigationTransitionInfo());
        }

        // Extras
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(BingMapPage), null, new DrillInNavigationTransitionInfo());
        }

        // Bottom

    }
}
