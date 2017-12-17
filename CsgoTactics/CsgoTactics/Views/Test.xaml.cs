//using System.IO;
using CsgoTactics.SteamInventory;
using CsgoTactics.Models.WeaponSkins;
using CsgoTactics.ViewModels;
using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using CsgoTactics.WebServices;
using CsgoTactics.Models.SteamInventory;
using Windows.UI.Core;
using DataAccessLibrary;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace CsgoTactics.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Test : Page
    {
        

        public Test()
        {
            this.InitializeComponent();
            //ViewModel.getSkins();
            
        }

        public TestViewModel ViewModel => this.DataContext as TestViewModel;

        private void TestPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack) this.Frame.GoBack();
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
            SystemNavigationManager.GetForCurrentView().BackRequested += TestPage_BackRequested;
            base.OnNavigatedTo(e);
        }

        private void AddData(object sender, RoutedEventArgs e)
        {
            //DataAccess.ReplaceData(Inventory.GetInventoryString()[0]);

            //DataAccess.InitializeDatabase();

            DataAccess.AddSteamInventory("123", "bdm");

            DataAccess.AddCsgoInventory(WebServices.DataReceiver.GetInventoryString("http://steamcommunity.com/profiles/76561197988463243/inventory/json/730/2"), "123", "720");

            //DataAccess.ResetDatabase();

            //DataAccess.AddData(Input_Box.Text);

            //Output.ItemsSource = DataAccess.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.ResetDatabase();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataAccess.AddCsgoInventory(WebServices.DataReceiver.GetInventoryString("http://steamcommunity.com/profiles/76561197988463243/inventory/json/730/2"), "123", "720");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataAccess.AddSteamInventory("123", "bdm");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var a = DataAccess.GetData();
        }
    }
}
