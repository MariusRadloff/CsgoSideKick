using CsgoTactics.Models.SteamInventory;
using CsgoTactics.Models.SteamInventory.Csgo;
using CsgoTactics.Models.WeaponSkins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CsgoTactics.ViewModels
{
    public class InventoryPageViewModel : INotifyPropertyChanged
    {
        private const String FILENAME = "InventoryData.xml";

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private InventoryState state;

        public InventoryState State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }

        private Inventory inventory;

        public Inventory Inventory
        {
            get { return inventory; }
            set
            {
                inventory = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> items;

        public ObservableCollection<WeaponSkinGroup> Items
        {
            get { return items; }
            set
            {
                items = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> invGroups;

        public ObservableCollection<WeaponSkinGroup> InvGroups
        {
            get { return invGroups; }
            set
            {
                invGroups = value;
                NotifyPropertyChanged();
            }
        }

        #region Collections
        private ObservableCollection<WeaponSkinGroup> pistols;

        public ObservableCollection<WeaponSkinGroup> Pistols
        {
            get
            {
                return pistols ?? GetItemGroupsOfType("CSGO_Type_Pistol");
            }
            set
            {
                pistols = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> rifles;

        public ObservableCollection<WeaponSkinGroup> Rifles
        {
            get
            {
                return rifles ?? GetItemGroupsOfType("CSGO_Type_Rifle");
            }
            set
            {
                rifles = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> snipers;

        public ObservableCollection<WeaponSkinGroup> Snipers
        {
            get
            {
                return snipers ?? GetItemGroupsOfType("CSGO_Type_SniperRifle");
            }
            set
            {
                snipers = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> smgs;

        public ObservableCollection<WeaponSkinGroup> Smgs
        {
            get
            {
                return smgs ?? GetItemGroupsOfType("CSGO_Type_SMG");
            }
            set
            {
                smgs = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> shotguns;

        public ObservableCollection<WeaponSkinGroup> Shotguns
        {
            get
            {
                return shotguns ?? GetItemGroupsOfType("CSGO_Type_Shotgun");
            }
            set
            {
                shotguns = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> heavy;

        public ObservableCollection<WeaponSkinGroup> Heavy
        {
            get
            {
                return heavy ?? GetItemGroupsOfType("CSGO_Type_Machinegun");
            }
            set
            {
                heavy = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> knives;

        public ObservableCollection<WeaponSkinGroup> Knives
        {
            get
            {
                return knives ?? GetItemGroupsOfType("CSGO_Type_Knive");
            }
            set
            {
                knives = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> cases;

        public ObservableCollection<WeaponSkinGroup> Cases
        {
            get
            {
                return cases ?? GetItemGroupsOfType("CSGO_Type_WeaponCase");
            }
            set
            {
                cases = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> stickers;

        public ObservableCollection<WeaponSkinGroup> Stickers
        {
            get
            {
                return stickers ?? GetItemGroupsOfType("CSGO_Tool_Sticker");
            }
            set
            {
                stickers = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> collectibles;

        public ObservableCollection<WeaponSkinGroup> Collectibles
        {
            get
            {
                return collectibles ?? GetItemGroupsOfType("CSGO_Type_Collectible");
            }
            set
            {
                collectibles = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> sprays;

        public ObservableCollection<WeaponSkinGroup> Sprays
        {
            get
            {
                return sprays ?? GetItemGroupsOfType("CSGO_Type_Spray");
            }
            set
            {
                sprays = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<WeaponSkinGroup> others;

        public ObservableCollection<WeaponSkinGroup> Others
        {
            get
            {
                return others ?? GetItemGroupsOfType("");
            }
            set
            {
                others = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public void UpdateItemGroupsCollections()
        {
            Pistols = GetItemGroupsOfType("CSGO_Type_Pistol");
            Rifles = GetItemGroupsOfType("CSGO_Type_Rifle");
            Snipers = GetItemGroupsOfType("CSGO_Type_SniperRifle");
            Smgs = GetItemGroupsOfType("CSGO_Type_SMG");
            Shotguns = GetItemGroupsOfType("CSGO_Type_Shotgun");
            Heavy = GetItemGroupsOfType("CSGO_Type_Machinegun");
            Knives = GetItemGroupsOfType("CSGO_Type_Knive");
            Cases = GetItemGroupsOfType("CSGO_Type_WeaponCase");
            Stickers = GetItemGroupsOfType("CSGO_Tool_Sticker");
            Collectibles = GetItemGroupsOfType("CSGO_Type_Collectible");
            Sprays = GetItemGroupsOfType("CSGO_Type_Spray");
            Others = GetItemGroupsOfType("");
        }

        private ObservableCollection<WeaponSkin> GetItemsOfType(string itemType)
        {
            ObservableCollection<WeaponSkin> itemcol = new ObservableCollection<WeaponSkin>();
            foreach (WeaponSkin skin in Inventory.SteamInventory)
            {
                if (skin.Tags[0].Internal_name == itemType)
                {
                    itemcol.Add(skin);
                }
            }
            return itemcol;
        }

        private ObservableCollection<WeaponSkinGroup> GetItemGroupsOfType(string groupCsgoType)
        {
            ObservableCollection<WeaponSkinGroup> itemcol = new ObservableCollection<WeaponSkinGroup>();
            foreach (WeaponSkinGroup skinGroup in InvGroups)
            {
                if (skinGroup.GroupCsgoType == groupCsgoType)
                {
                    itemcol.Add(skinGroup);
                }
            }
            return itemcol;
        }

        private ObservableCollection<WeaponSkin> GetItemsOfTypes(string[] itemTypes)
        {
            ObservableCollection<WeaponSkin> itemcol = new ObservableCollection<WeaponSkin>();
            foreach (WeaponSkin skin in Inventory.SteamInventory)
            {
                foreach (string type in itemTypes)
                {
                    if (skin.Tags[0].Internal_name == type)
                    {
                        itemcol.Add(skin);
                    }
                }
            }
            return itemcol;
        }

        public ObservableCollection<WeaponSkinGroup> GetPistolGroupsOfName(string pistolGroupName)
        {
            ObservableCollection<WeaponSkinGroup> itemcol = new ObservableCollection<WeaponSkinGroup>();
            foreach (WeaponSkinGroup skinGroup in InvGroups)
            {
                if (skinGroup.InvGroup[0].Tags[1].Name == pistolGroupName)
                {
                    itemcol.Add(skinGroup);
                }
            }
            return itemcol;
        }

        public ObservableCollection<WeaponSkinGroup> GetSkinGroups(ObservableCollection<WeaponSkin> inv)
        {
            ObservableCollection<WeaponSkinGroup> invGroup = new ObservableCollection<WeaponSkinGroup>();

            var groups = inv.GroupBy(WeaponSkin => WeaponSkin.Name);


            foreach (var sg in groups)
            {
                WeaponSkinGroup g = new WeaponSkinGroup();
                g.GroupItemCount = sg.Count();
                g.GroupName = sg.Key;
                g.GroupCsgoType = sg.FirstOrDefault<WeaponSkin>().Tags[0].Internal_name;
                g.InvGroup = new ObservableCollection<WeaponSkin>();
                foreach (var s in sg)
                {
                    g.InvGroup.Add(s);
                }
                invGroup.Add(g);
            }
            return invGroup;
        }

        public ObservableCollection<WeaponSkin> GetCloneOfCollection(ObservableCollection<WeaponSkin> col)
        {
            ObservableCollection<WeaponSkin> clonedCollection = new ObservableCollection<WeaponSkin>();

            foreach (var item in col)
            {
                clonedCollection.Add(item.ShallowCopy());
            }
            return clonedCollection;
        }

        public ObservableCollection<WeaponSkinGroup> GetCloneOfCollection(ObservableCollection<WeaponSkinGroup> col)
        {
            ObservableCollection<WeaponSkinGroup> clonedCollection = new ObservableCollection<WeaponSkinGroup>();

            foreach (var item in col)
            {
                clonedCollection.Add(item.ShallowCopy());
            }
            return clonedCollection;
        }


        public async Task<bool> SerializeInventoryAsync()
        {
            var serializer = new DataContractSerializer(typeof(Inventory));
            try
            {
                using (Stream serStream = ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FILENAME, CreationCollisionOption.ReplaceExisting).Result)
                {
                    serializer.WriteObject(serStream, Inventory);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                //throw;
            }
        }

        public async Task<bool> DeserializeInventoryAsync()
        {
            var serializer = new DataContractSerializer(typeof(Inventory));
            try
            {
                using (var stream = ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FILENAME).Result)
                {
                    Inventory = (Inventory)serializer.ReadObject(stream);
                }
                return true;
            }
            catch (Exception e)
            {
                //throw; Datei kann nicht geöffnet werden
                return false;
            }
        }

        public enum InventoryState
        {
            Error,
            None,
            Loaded,
            Loading
        }

        internal void SortItems()
        {
            var col = Items.OrderBy(WeaponSkinGroup => WeaponSkinGroup.GroupName);
            ObservableCollection<WeaponSkinGroup> col2 = new ObservableCollection<WeaponSkinGroup>();
            foreach (var item in col)
            {
                col2.Add(item.ShallowCopy());
            }

            Items = col2;
        }
    }
}
