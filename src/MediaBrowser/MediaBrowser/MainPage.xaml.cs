/*
 * MediaBrowser, A Modern version of Windows Media Center
 * Copyright (C) 2022 - 2024 - v38armageddon
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
namespace MediaBrowser;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    // Top
    private void buttonWindow_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void buttonClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Exit();
    }

    // Center
    // Task
    private async void buttonExit_Click(object sender, RoutedEventArgs e)
    {
        Dialogs.ExitDialog exitDialog = new Dialogs.ExitDialog();
        exitDialog.XamlRoot = this.XamlRoot;
        ContentDialogResult result = await exitDialog.ShowAsync();
    }

    private async void buttonAbout_Click(object sender, RoutedEventArgs e)
    {
        Dialogs.AboutDialog aboutDialog = new Dialogs.AboutDialog();
        aboutDialog.XamlRoot = this.XamlRoot;
        ContentDialogResult result = await aboutDialog.ShowAsync();
    }

    // Pictures
    private void myPicturesButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void cameraButton_Click(object sender, RoutedEventArgs e)
    {

    }

    // Music
    private void myMusicButton_Click(object sender, RoutedEventArgs e)
    {

    }

    // Videos
    private void myVideosButton_Click(object sender, RoutedEventArgs e)
    {

    }

    // Extras
    private void bingMapButton_Click(object sender, RoutedEventArgs e)
    {

    }
}
