using CsgoTactics.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class InGameLivePage : Page
    {
        public static InGameLivePage Current;

        List<Scenario> scenarios = new List<Scenario>{
            new Scenario() { Title="Overview", ClassType=typeof(InGameLivePageScenarios.Scenario1_Overview) },
            new Scenario() { Title="Equipment", ClassType = typeof(InGameLivePageScenarios.Scenario2_Equipment) },
            new Scenario() { Title="Armor", ClassType=typeof(InGameLivePageScenarios.Scenario3_Armor) },
            new Scenario() { Title="Bomb", ClassType=typeof(InGameLivePageScenarios.Scenario4_Bomb) },
            new Scenario() { Title="Statistics", ClassType=typeof(InGameLivePageScenarios.Scenario5_Stats) },
        };

        public List<Scenario> Scenarios
        {
            get { return this.scenarios; }
        }

        private InGameLivePageViewModel ViewModel => this.DataContext as InGameLivePageViewModel;

        public InGameLivePage()
        {
            Current = this;
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Populate the scenario list from the SampleConfiguration.cs file

            ScenarioControl.ItemsSource = scenarios;
            if (Window.Current.Bounds.Width < 640)
            {
                ScenarioControl.SelectedIndex = -1;
            }
            else
            {
                ScenarioControl.SelectedIndex = 0;
            }

            if (this.Frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            SystemNavigationManager.GetForCurrentView().BackRequested += InGameLivePage_BackRequested;
            base.OnNavigatedTo(e);
        }


        /// <summary>
        /// Called whenever the user changes selection in the scenarios list.  This method will navigate to the respective
        /// sample scenario page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScenarioControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear the status block when navigating scenarios.
            //NotifyUser(String.Empty, NotifyType.StatusMessage);

            ListBox scenarioListBox = sender as ListBox;
            Scenario s = scenarioListBox.SelectedItem as Scenario;
            if (s != null)
            {
                ScenarioFrame.Navigate(s.ClassType);
                if (Window.Current.Bounds.Width < 640)
                {
                    Splitter.IsPaneOpen = false;
                }
            }
        }

        private void PaneToggleButton_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }


        //protected async override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        //    SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        //    base.OnNavigatedTo(e);
        //}

        private void InGameLivePage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack) this.Frame.GoBack();
        }

    }
}
