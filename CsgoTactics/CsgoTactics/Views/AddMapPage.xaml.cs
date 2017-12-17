using CsgoTactics.Models;
using CsgoTactics.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace CsgoTactics.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AddMapPage : Page
    {
        public AddMapPageViewModel ViewModel => this.DataContext as AddMapPageViewModel;

        public AddMapPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonAddIcon_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Windows.Storage.Pickers.FileOpenPicker();
            fileDialog.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            fileDialog.FileTypeFilter.Add(".jpg");
            fileDialog.FileTypeFilter.Add(".png");
            fileDialog.FileTypeFilter.Add(".jpeg");
            fileDialog.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads;
            StorageFile file = await fileDialog.PickSingleFileAsync();
            if (file != null)
            {
                ViewModel.Map.MapIconImagePath = file.Path;
                //await file.CopyAsync(StorageFolder.GetFolderFromPathAsync("ms-appx:///"));
                //await file.CopyAsync()
            }
        }

        private async void ButtonAddMap_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Windows.Storage.Pickers.FileOpenPicker();
            fileDialog.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            fileDialog.FileTypeFilter.Add(".jpg");
            fileDialog.FileTypeFilter.Add(".png");
            fileDialog.FileTypeFilter.Add(".jpeg");
            fileDialog.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads;
            StorageFile file = await fileDialog.PickSingleFileAsync();
            if (file != null)
            {
                ViewModel.Map.MapImagePath = file.Path;
            }
        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            base.OnNavigatedTo(e);
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack) this.Frame.GoBack();
        }
    }
}
