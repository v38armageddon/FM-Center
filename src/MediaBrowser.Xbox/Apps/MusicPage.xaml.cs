﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;

namespace MediaBrowser.Apps
{
    public sealed partial class MusicPage : Page
    {
        private List<StorageFile> files = new List<StorageFile>();
        private int currentFileIndex = 0;

        public MusicPage()
        {
            this.InitializeComponent();
        }

        // Top
        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), null, new DrillInNavigationTransitionInfo());
        }

        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayerElement.Source = null;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), null, new DrillInNavigationTransitionInfo());
        }

        // Center
        private async void openFileButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            FileOpenPicker p = new FileOpenPicker();
            p.FileTypeFilter.Add(".mp3");
            p.FileTypeFilter.Add(".ogg");
            p.FileTypeFilter.Add(".wav");
            p.FileTypeFilter.Add(".flac");
            var selectedFiles = await p.PickMultipleFilesAsync();
            if (selectedFiles.Count == 0) return;
            files = selectedFiles.ToList();
            var source = MediaSource.CreateFromStorageFile(files[currentFileIndex]);
            mediaPlayerElement.Source = source;
            mediaPlayerElement.AutoPlay = true;
            playButton.Visibility = Visibility.Collapsed;
            pauseButton.Visibility = Visibility.Visible;
        }

        // Bottom
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayerElement.AutoPlay = false;
            mediaPlayerElement.Source = null;
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayerElement.Source == null)
            {
                infoBar.Visibility = Visibility.Visible;
            }
            else
            {
                if (currentFileIndex == 0)
                    currentFileIndex = files.Count - 1;
                else
                    currentFileIndex--;
                var source = MediaSource.CreateFromStorageFile(files[currentFileIndex]);
                mediaPlayerElement.Source = source;
                mediaPlayerElement.MediaPlayer.Play();
            }
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayerElement.Source == null)
            {
                infoBar.Visibility = Visibility.Visible;
            }
            else
            {
                mediaPlayerElement.MediaPlayer.Play();
                playButton.Visibility = Visibility.Collapsed;
                pauseButton.Visibility = Visibility.Visible;
            }
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayerElement.Source == null)
            {
                infoBar.Visibility = Visibility.Visible;
            }
            else
            {
                mediaPlayerElement.MediaPlayer.Pause();
                playButton.Visibility = Visibility.Visible;
                pauseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayerElement.Source == null)
            {
                infoBar.Visibility = Visibility.Visible;
            }
            else
            {
                if (currentFileIndex == files.Count - 1)
                    currentFileIndex = 0;
                else
                    currentFileIndex++;
                var source = MediaSource.CreateFromStorageFile(files[currentFileIndex]);
                mediaPlayerElement.Source = source;
                mediaPlayerElement.MediaPlayer.Play();
            }
        }

        private void infoBar_CloseButtonClick(Microsoft.UI.Xaml.Controls.InfoBar sender, object args)
        {
            infoBar.Visibility = Visibility.Collapsed;
        }
    }
}