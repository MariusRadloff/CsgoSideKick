using CsgoTactics.Models;
using CsgoTactics.ViewModels;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace CsgoTactics.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        Map activeMap = new Map();

        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
            this.NavigationCacheMode = NavigationCacheMode.Required;

            if (ViewModel.Maps.Count == 0)
            {
                ViewModel.Maps.Add(new Map("de_mirage", "Mirage", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_mirage-map-callouts.jpg", "ms-appx:///Images/Icons/icon_mirage.png", "no description"));
                ViewModel.Maps.Add(new Map("de_dust2", "Dust2", "Bomb", "Terrorist", "ms-appx:///Images/Maps/de_dust2-map-callouts.jpg", "ms-appx:///Images/Icons/icon_dust_2.png", "no description"));
                ViewModel.Maps.Add(new Map("de_inferno", "Inferno", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_inferno-map-callouts.jpg", "ms-appx:///Images/Icons/icon_inferno.png", "no description"));
                ViewModel.Maps.Add(new Map("de_nuke", "Nuke", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_nuke-map-callouts.jpg", "ms-appx:///Images/Icons/icon_nuke.png", "no description"));
                ViewModel.Maps.Add(new Map("de_cache", "Cache", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_cache-map-callouts.jpg", "ms-appx:///Images/Icons/icon_cache.png", "no description"));
                ViewModel.Maps.Add(new Map("de_cbble", "Cobblestone", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_cbble-map-callouts.jpg", "ms-appx:///Images/Icons/icon_cbble.png", "no description"));
                ViewModel.Maps.Add(new Map("de_overpass", "Overpass", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_overpass-map-callouts.jpg", "ms-appx:///Images/Icons/icon_overpass.png", "no description"));
                ViewModel.Maps.Add(new Map("de_train", "Train", "Bomb", "n.a.", "ms-appx:///Images/Maps/de_train-map-callouts.jpg", "ms-appx:///Images/Icons/icon_train.png", "no description"));
            }

            MapsList.ItemsSource = ViewModel.Maps;
            MapsList.SelectedIndex = MapsList.Items.IndexOf(MapsList.Items.FirstOrDefault());
            activeMap = ViewModel.Maps.ElementAtOrDefault(MapsList.Items.IndexOf(MapsList.Items.FirstOrDefault()));

            activeMap.MapStat.WonGames = 50.0;
            activeMap.MapStat.LostGames = 30.0;
            activeMap.MapStat.TiedGames = 20.0;

            activeMap.MapStat.WonCtRounds = 50.0;
            activeMap.MapStat.WonTRounds = 30.0;
            activeMap.MapStat.LostCtRounds = 3.0;
            activeMap.MapStat.LostTRounds = 7.0;
            activeMap.MapStat.MvpRounds = 15.0;

            activeMap.MapStat.TotalFrags = 500.0;
            activeMap.MapStat.HsFrags = 80.0;
            activeMap.MapStat.Accuracy = 0.025;

            ViewModel.SerializeMapsData();


        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            activeMap = (Map)e.ClickedItem;
        }

        private void AddMapButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddMapPage), true);
        }

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), true);
        }

        private void InventoryPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InventoryPage), true);
        }

        private void LivePageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InGameLivePage), true);
        }

        private void OptionsPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsPage), true);
        }

        private void TestPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test), true);
        }

        private void EditMapButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditMapPage), true);
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

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }
    }
}
