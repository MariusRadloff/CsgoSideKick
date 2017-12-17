using CsgoTactics.Models.WeaponSkins;
using CsgoTactics.ViewModels;
using CsgoTactics.WebServices;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static CsgoTactics.Models.SteamInventory.SteamItem;
using CsgoTactics.Models.SteamInventory.Csgo;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace CsgoTactics.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class InventoryPage : Page
    {
        public static InventoryPage Current;
        public InventoryPageViewModel ViewModel; //=> this.DataContext as InventoryPageViewModel;


        public InventoryPage()
        {

            //this.InitializeComponent();
            Current = this;
            ViewModel = new InventoryPageViewModel();
            this.DataContext = ViewModel;
            this.NavigationCacheMode = NavigationCacheMode.Required;

            ViewModel.State = InventoryPageViewModel.InventoryState.None;

            var x = ViewModel.DeserializeInventoryAsync().Result;
            if (ViewModel.Inventory != null && ViewModel.Inventory.SteamInventory != null)
            {
                ViewModel.InvGroups = ViewModel.GetSkinGroups(ViewModel.Inventory.SteamInventory);
                ViewModel.Items = ViewModel.GetCloneOfCollection(ViewModel.InvGroups);
                ViewModel.State = InventoryPageViewModel.InventoryState.Loaded;
            }

            //ViewModel.InvGroups = ViewModel.GetSkinGroups(ViewModel.Inventory.SteamInventory);

            //ViewModel.Items = ViewModel.InvGroups;

            this.InitializeComponent();
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

            //if (ViewModel.DeserializeInventoryAsync().Result)
            //{
            //    ViewModel.State = InventoryPageViewModel.InventoryState.Loaded;
            //}

            //ViewModel.DeserializeInventoryAsync();
            //if (ViewModel.Inventory != null && ViewModel.Inventory.SteamInventory != null)
            //{
            //    ViewModel.State = InventoryPageViewModel.InventoryState.Loaded;
            //}



            //this.InitializeComponent();

            base.OnNavigatedTo(e);

        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack) this.Frame.GoBack();
        }

        #region Navi
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
        #endregion

        #region Filter

        private void AddGroupToItemsCollection(object sender, ObservableCollection<WeaponSkinGroup> itemSource, ObservableCollection<WeaponSkinGroup> itemTarget)
        {
            foreach (var group in itemSource.Where(group => group.InvGroup[0].Tags[1].Name == ((CheckBox)sender).Content.ToString()).Select(group => group))
            {
                itemTarget.Add(group.ShallowCopy());
            }
        }

        private void RemoveGroupFromItemsCollection(object sender, ObservableCollection<WeaponSkinGroup> collection)
        {
            ObservableCollection<WeaponSkinGroup> col = new ObservableCollection<WeaponSkinGroup>();

            foreach (var group in collection.Where(group => group.InvGroup[0].Tags[1].Name == ((CheckBox)sender).Content.ToString()).Select(group => group))
            {
                col.Add(group);
            }

            foreach (var group in col)
            {
                collection.Remove(group);
            }
        }

        private void CheckAllCheckBoxesInPanel(object panel)
        {
            var childrenCollection = ((Panel)panel).Children;

            foreach (var child in childrenCollection)
            {
                if (child.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)child).IsChecked = true;
                }
            }
        }

        private void UncheckAllCheckBoxesInPanel(object panel)
        {
            var childrenCollection = ((Panel)panel).Children;

            foreach (var child in childrenCollection)
            {
                if (child.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)child).IsChecked = false;
                }
            }
        }

        #region CheckBoxFilter

        private void AllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //ViewModel.Items = ViewModel.GetCloneOfCollection(ViewModel.InvGroups);
            //ViewModel.SortItems();

            ViewModel.Items = new ObservableCollection<WeaponSkinGroup>();

            PistolsCheckBox.IsChecked = true;
            RiflesCheckBox.IsChecked = true;
            SnipersCheckBox.IsChecked = true;
            SmgsCheckBox.IsChecked = true;
            HeavysCheckBox.IsChecked = true;
            KnivesCheckBox.IsChecked = true;
            CasesCheckBox.IsChecked = true;
            StickersCheckBox.IsChecked = true;
            SpraysCheckBox.IsChecked = true;
            CollectiblesCheckBox.IsChecked = true;
            //OthersCheckBox.IsChecked = true;
        }

        private void AllCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //ViewModel.Items.Clear();

            PistolsCheckBox.IsChecked = false;
            RiflesCheckBox.IsChecked = false;
            SnipersCheckBox.IsChecked = false;
            SmgsCheckBox.IsChecked = false;
            HeavysCheckBox.IsChecked = false;
            KnivesCheckBox.IsChecked = false;
            CasesCheckBox.IsChecked = false;
            StickersCheckBox.IsChecked = false;
            SpraysCheckBox.IsChecked = false;
            CollectiblesCheckBox.IsChecked = false;

            ViewModel.Items.Clear();
            //OthersCheckBox.IsChecked = false;
        }


        private void PistolsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Pistols)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            CheckAllCheckBoxesInPanel(PistolFilterStackPanel);

            ViewModel.SortItems();
        }

        private void PistolsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Pistols)
            {
                if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            UncheckAllCheckBoxesInPanel(PistolFilterStackPanel);

            ViewModel.SortItems();
        }

        private void PistolNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Pistols, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void PistolNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void RiflesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Rifles)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            CheckAllCheckBoxesInPanel(RifleFilterStackPanel);

            ViewModel.SortItems();
        }

        private void RiflesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Rifles)
            {
                if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            UncheckAllCheckBoxesInPanel(RifleFilterStackPanel);

            ViewModel.SortItems();
        }

        private void RifleNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Rifles, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void RifleNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void SnipersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Snipers)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            CheckAllCheckBoxesInPanel(SniperFilterStackPanel);

            ViewModel.SortItems();
        }

        private void SnipersCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Snipers)
            {
                if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            UncheckAllCheckBoxesInPanel(SniperFilterStackPanel);

            ViewModel.SortItems();
        }

        private void SniperNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Snipers, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void SniperNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void SmgsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Smgs)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            CheckAllCheckBoxesInPanel(SmgFilterStackPanel);

            ViewModel.SortItems();
        }

        private void SmgsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Smgs)
            {
                if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            UncheckAllCheckBoxesInPanel(SmgFilterStackPanel);

            ViewModel.SortItems();
        }

        private void SmgNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Smgs, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void SmgNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void HeavysCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Heavy)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            CheckAllCheckBoxesInPanel(HeavyFilterStackPanel);

            ViewModel.SortItems();
        }

        private void HeavysCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Smgs)
            {
                if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            UncheckAllCheckBoxesInPanel(HeavyFilterStackPanel);

            ViewModel.SortItems();
        }

        private void HeavyNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Heavy, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void HeavyNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void KnivesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Knives)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            CheckAllCheckBoxesInPanel(KniveFilterStackPanel);

            ViewModel.SortItems();
        }

        private void KnivesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Knives)
            {
                if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
                {
                    ViewModel.Items.Remove(item);
                }
            }

            UncheckAllCheckBoxesInPanel(KniveFilterStackPanel);

            ViewModel.SortItems();
        }

        private void KniveNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Knives, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void KniveNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void CasesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Version, für erstellte checkboxen
            //foreach (var item in ViewModel.Cases)
            //{
            //    if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //

            //Version ohne einzelne Checkboxen
            foreach (var item in ViewModel.Cases)
            {
                if (!ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Add(item);
                }
            }

            CheckAllCheckBoxesInPanel(CaseFilterStackPanel);

            ViewModel.SortItems();
        }

        private void CasesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Version, für erstellte checkboxen
            //foreach (var item in ViewModel.Stickers)
            //{
            //    if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            ObservableCollection<WeaponSkinGroup> col = new ObservableCollection<WeaponSkinGroup>();
            foreach (var item in ViewModel.Cases)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    var i = ViewModel.Items.Where(x => x.GroupName == item.GroupName);
                    foreach (var a in i)
                    {
                        col.Add(a);
                    }
                }
            }

            foreach (var group in col)
            {
                ViewModel.Items.Remove(group);
            }

            UncheckAllCheckBoxesInPanel(CaseFilterStackPanel);

            ViewModel.SortItems();
        }

        private void CaseNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Cases, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void CaseNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void StickersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //foreach (var item in ViewModel.Stickers)
            //{
            //    if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            foreach (var item in ViewModel.Stickers)
            {
                if (!ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Add(item);
                }
            }

            CheckAllCheckBoxesInPanel(StickerFilterStackPanel);

            ViewModel.SortItems();
        }

        private void StickersCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Version mit einzelne Checkboxen
            //foreach (var item in ViewModel.Stickers)
            //{
            //    if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            ObservableCollection<WeaponSkinGroup> col = new ObservableCollection<WeaponSkinGroup>();
            foreach (var item in ViewModel.Stickers)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    var i = ViewModel.Items.Where(x => x.GroupName == item.GroupName);
                    foreach (var a in i)
                    {
                        col.Add(a);
                    }
                }
            }

            foreach (var group in col)
            {
                ViewModel.Items.Remove(group);
            }

            UncheckAllCheckBoxesInPanel(StickerFilterStackPanel);

            ViewModel.SortItems();
        }

        private void StickerNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Stickers, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void StickerNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void SpraysCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //foreach (var item in ViewModel.Sprays)
            //{
            //    if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            foreach (var item in ViewModel.Sprays)
            {
                if (!ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Add(item);
                }
            }

            CheckAllCheckBoxesInPanel(SprayFilterStackPanel);

            ViewModel.SortItems();
        }

        private void SpraysCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Version mit einzelne Checkboxen
            //foreach (var item in ViewModel.Sprays)
            //{
            //    if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            ObservableCollection<WeaponSkinGroup> col = new ObservableCollection<WeaponSkinGroup>();
            foreach (var item in ViewModel.Sprays)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    var i = ViewModel.Items.Where(x => x.GroupName == item.GroupName);
                    foreach (var a in i)
                    {
                        col.Add(a);
                    }
                }
            }

            foreach (var group in col)
            {
                ViewModel.Items.Remove(group);
            }

            UncheckAllCheckBoxesInPanel(SprayFilterStackPanel);

            ViewModel.SortItems();
        }

        private void SprayNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Sprays, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void SprayNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void CollectiblesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //foreach (var item in ViewModel.Collectibles)
            //{
            //    if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            foreach (var item in ViewModel.Collectibles)
            {
                if (!ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Add(item);
                }
            }

            CheckAllCheckBoxesInPanel(CollectibleFilterStackPanel);

            ViewModel.SortItems();
        }

        private void CollectiblesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Version ohne einzelne Checkboxen
            //foreach (var item in ViewModel.Collectibles)
            //{
            //    if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            ObservableCollection<WeaponSkinGroup> col = new ObservableCollection<WeaponSkinGroup>();
            foreach (var item in ViewModel.Collectibles)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    var i = ViewModel.Items.Where(x => x.GroupName == item.GroupName);
                    foreach (var a in i)
                    {
                        col.Add(a);
                    }
                }
            }

            foreach (var group in col)
            {
                ViewModel.Items.Remove(group);
            }

            UncheckAllCheckBoxesInPanel(CollectibleFilterStackPanel);

            ViewModel.SortItems();
        }

        private void CollectibleNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Collectibles, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void CollectibleNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }


        private void OthersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //foreach (var item in ViewModel.Others)
            //{
            //    if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            foreach (var item in ViewModel.Others)
            {
                if (!ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    ViewModel.Items.Add(item);
                }
            }

            CheckAllCheckBoxesInPanel(OtherFilterStackPanel);

            ViewModel.SortItems();
        }

        private void OthersCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Version mit einzelne Checkboxen
            //foreach (var item in ViewModel.Collectibles)
            //{
            //    if (ViewModel.Items.Contains(ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault()))
            //    {
            //        ViewModel.Items.Remove(item);
            //    }
            //}

            //Version ohne einzelne Checkboxen
            ObservableCollection<WeaponSkinGroup> col = new ObservableCollection<WeaponSkinGroup>();
            foreach (var item in ViewModel.Others)
            {
                if (ViewModel.Items.Contains((ViewModel.Items.Where(x => x.GroupName == item.GroupName).FirstOrDefault())))
                {
                    var i = ViewModel.Items.Where(x => x.GroupName == item.GroupName);
                    foreach (var a in i)
                    {
                        col.Add(a);
                    }
                }
            }

            foreach (var group in col)
            {
                ViewModel.Items.Remove(group);
            }

            UncheckAllCheckBoxesInPanel(OtherFilterStackPanel);

            ViewModel.SortItems();
        }

        private void OtherNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddGroupToItemsCollection(sender, ViewModel.Others, ViewModel.Items);

            ViewModel.SortItems();
        }

        private void OtherNameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveGroupFromItemsCollection(sender, ViewModel.Items);

            ViewModel.SortItems();
        }
        #endregion

        #endregion

        private void LoadInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            LoadInventoryButton.IsEnabled = false;

            //Asynchroner Aufruf der Funktionen

            ViewModel.Inventory = new Models.SteamInventory.Inventory();

            ViewModel.Inventory.GenerateInventory();

            ViewModel.Items = ViewModel.GetSkinGroups(ViewModel.Inventory.SteamInventory);

            ViewModel.InvGroups = ViewModel.Items; //Test

            ViewModel.SortItems();

            ViewModel.UpdateItemGroupsCollections();

            ViewModel.State = InventoryPageViewModel.InventoryState.Loaded;

            //ViewModel.SerializeInventory();

            //Synchroner Aufruf der Funktionen

            //ViewModel.Inventory = new Models.SteamInventory.Inventory();

            //ViewModel.Inventory.GenerateInventory();

            //ViewModel.Items = ViewModel.Inventory.SteamInventory;

            //ViewModel.SerializeInventory();

            LoadInventoryButton.IsEnabled = true;
        }

        private void GetPriceButton_Click(object sender, RoutedEventArgs e)
        {

            //string s = DataReceiver.GetMarketPriceoverview("3", ((WeaponSkin)((Button)sender).DataContext).AppId, ((WeaponSkin)((Button)sender).DataContext).Market_hash_name);
            WeaponSkin skin = ((WeaponSkin)((Button)sender).DataContext);

            SteamPrice price = DataReceiver.GetMarketPriceoverview("3", skin.AppId, skin.Market_hash_name);

            //skin.PriceCol.Insert(0, DataReceiver.GetMarketPriceoverview("3", skin.AppId, skin.Market_hash_name));
            foreach (WeaponSkin s in ViewModel.Inventory.SteamInventory)
            {
                if (s.Market_hash_name == skin.Market_hash_name)
                {
                    if (s.PriceCol == null)
                    {
                        s.PriceCol = new ObservableCollection<Models.SteamInventory.SteamItem.SteamPrice>();
                    }
                    s.PriceCol.Insert(0, price);
                }
            }
        }

        private void SerializeInventory_Click(object sender, RoutedEventArgs e)
        {
            var x = ViewModel.SerializeInventoryAsync().Result;
        }

        private void ItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            DescriptionStackPanel.Children.Clear();

            SelectedItemStackPanel.DataContext = e.ClickedItem;

            for (int i = 0; i < ((WeaponSkin)e.ClickedItem).Descriptions.Count; i++)
            {
                TextBlock tb = new TextBlock();
                var text = ((WeaponSkin)e.ClickedItem).Descriptions[i].Value;

                if (text.Contains("<i>") ^ text.Contains("<b>"))
                {
                    string a = "", b = "", c = "";
                    a = text;
                    while (a.Contains("<i>"))
                    {
                        b = text.Substring(0, a.IndexOf("<i>"));
                        tb.Inlines.Add(new Run() { Text = b });

                        c = text.Substring(a.IndexOf("<i>") + 3, a.IndexOf("</i>") - (a.IndexOf("<i>") + 3));
                        tb.Inlines.Add(new Run() { Text = c, FontStyle = Windows.UI.Text.FontStyle.Italic });

                        a = a.Substring(a.IndexOf("</i>") + 4);
                    }


                    while (a.Contains("<b>"))
                    {
                        b = text.Substring(0, a.IndexOf("<b>"));
                        tb.Inlines.Add(new Run() { Text = b });

                        c = text.Substring(a.IndexOf("<b>") + 3, a.IndexOf("</b>") - (a.IndexOf("<b>") + 3));
                        tb.Inlines.Add(new Run() { Text = c, FontWeight = Windows.UI.Text.FontWeights.Bold });

                        a = a.Substring(a.IndexOf("</b>") + 4);
                    }
                    tb.Inlines.Add(new Run() { Text = a });
                }
                else
                {
                    tb.Text = text;
                }

                tb.Width = 400;
                tb.TextWrapping = TextWrapping.WrapWholeWords;
                if (((WeaponSkin)e.ClickedItem).Descriptions[i].Color != null)
                {
                    var name_color = ((WeaponSkin)e.ClickedItem).Descriptions[i].Color;
                    tb.Foreground = new SolidColorBrush(Color.FromArgb(Byte.Parse(name_color.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier), Byte.Parse(name_color.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier), Byte.Parse(name_color.Substring(5, 2), System.Globalization.NumberStyles.AllowHexSpecifier), Byte.Parse(name_color.Substring(7, 2), System.Globalization.NumberStyles.AllowHexSpecifier)));
                }

                DescriptionStackPanel.Children.Add(tb);
            }
        }

        private void ItemGroupsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
