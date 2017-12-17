using CsgoTactics.Models.WeaponSkins;
using CsgoTactics.WebServices;
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
using Windows.Data.Json;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace CsgoTactics.Models.SteamInventory
{
    /* 
    In dieser Klasse wird das Inventar          
    */
    [DataContract()]
    public class Inventory : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        private string inventorySteam64Id;

        [DataMember]
        public string InventorySteam64Id
        {
            get { return inventorySteam64Id; }
            set { inventorySteam64Id = value; }

        }

        [DataMember]
        private ObservableCollection<WeaponSkin> steamInventory;

        [DataMember]
        public ObservableCollection<WeaponSkin> SteamInventory
        {
            get { return steamInventory; }
            set
            {
                steamInventory = value;
                NotifyPropertyChanged();
            }
        }

        [DataMember]
        private string[] inventoryStrings;

        [DataMember]
        public string[] InventoryStrings
        {
            get { return inventoryStrings; }
            set {
                inventoryStrings = value;
                NotifyPropertyChanged();
            }
        }

        internal ObservableCollection<WeaponSkin> GetInventory()
        {
            return steamInventory;
        }

        /* Mit dieser Funktion werden aus den beiden Json-Files aus der Steam-API die Elemente aus dem Inventar bereitgestellt.
         * Die Links zu den Json-Files:
         * Json 1 : http://api.steampowered.com/IEconItems_730/GetPlayerItems/v0001/?key=BD53E35BE3185B7BEE6E28B4564907B4&SteamID=76561197988463243 mit API-Key: BD53E35BE3185B7BEE6E28B4564907B4 und Steam64ID: 76561197988463243
         * Json 2 : http://steamcommunity.com/profiles/76561197988463243/inventory/json/730/2 mit Steam64ID: 76561197988463243
         * -
         *  */
        public void ParseJsonInventory()
        {
            #region inventoryString1

            JsonObject root1 = JsonObject.Parse(GetInventoryString()[0]);

            JsonObject rgInventory = root1.GetNamedObject("rgInventory");
            JsonObject rgDescriptions = root1.GetNamedObject("rgDescriptions");
            JsonArray rgCurrency = root1.GetNamedArray("rgCurrency");
            bool success = root1.GetNamedBoolean("success");
            bool more = root1.GetNamedBoolean("more");
            bool more_start = root1.GetNamedBoolean("more_start");

            for (int i = 0; i < rgInventory.Count; i++)
            {
                WeaponSkin skin = new WeaponSkin();
                JsonObject element = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);
                skin.Id = element.GetNamedString("id");
                skin.ClassId = element.GetNamedString("classid");
                skin.InstanceId = element.GetNamedString("instanceid");
                skin.Amount = element.GetNamedString("amount");
                skin.Pos = element.GetNamedNumber("pos");

                skin.PriceCol = new ObservableCollection<SteamItem.SteamPrice>();
                skin.PriceCol.Add(new SteamItem.SteamPrice());
                skin.BuyPrice = new SteamItem.PurchaseData();

                SteamInventory.Add(skin);
            }

            for (int i = 0; i < rgDescriptions.Count; i++)
            {
                JsonObject element = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(i).Key);
                var skinSel = from skins in SteamInventory where string.Equals(element.GetNamedString("classid"), skins.ClassId) select skins;
                int j = skinSel.Count();
                for (int n = 0; n < j; n++)
                {
                    WeaponSkin skin = skinSel.ElementAt(n);
                    //skin.AppId = element.GetNamedString("appid");
                    skin.Icon_url = element.GetNamedString("icon_url");
                    if (element.ContainsKey("icon_url_large")) { skin.Icon_url_large = element.GetNamedString("icon_url_large"); }
                    if (element.ContainsKey("icon_drag_url")) { skin.Icon_drag_url = element.GetNamedString("icon_drag_url"); }
                    if (element.ContainsKey("name")) { skin.Name = element.GetNamedString("name"); }
                    if (element.ContainsKey("market_hash_name")) { skin.Market_hash_name = element.GetNamedString("market_hash_name"); }
                    if (element.ContainsKey("market_name")) { skin.Market_name = element.GetNamedString("market_name"); }
                    if (element.ContainsKey("name_color")) { skin.Name_color = element.GetNamedString("name_color"); }
                    if (element.ContainsKey("background_color")) { skin.Background_color = element.GetNamedString("background_color"); }
                    if (element.ContainsKey("type")) { skin.Type = element.GetNamedString("type"); }
                    if (element.ContainsKey("tradable")) { skin.Tradable = element.GetNamedNumber("tradable"); }
                    if (element.ContainsKey("marketable")) { skin.Marketable = element.GetNamedNumber("marketable"); }
                    if (element.ContainsKey("commodity")) { skin.Commodity = element.GetNamedNumber("commodity"); }
                    if (element.ContainsKey("market_tradable_restriction")) { skin.Market_tradable_restriction = element.GetNamedString("market_tradable_restriction"); }
                    if (element.ContainsKey("appid")) { skin.AppId = element.GetNamedString("appid"); }
                    if (element.ContainsKey("descriptions"))
                    {
                        skin.Descriptions = new List<CsgoItem.Description>();
                        var des = element.GetNamedArray("descriptions");
                        for (uint m = 0; m < des.Count; m++)
                        {
                            var u = des.GetObjectAt(m);
                            
                            CsgoItem.Description d = new CsgoItem.Description();
                            if (u.ContainsKey("type")) { d.Type = u.GetNamedString("type"); }
                            if (u.ContainsKey("value")) { d.Value = u.GetNamedString("value"); }
                            if (u.ContainsKey("color")) { d.Color = u.GetNamedString("color"); }

                            skin.Descriptions.Add(d);
                        }
                    }
                    if (element.ContainsKey("tags"))
                    {
                        skin.Tags = new List<CsgoItem.Tag>();
                        var tags = element.GetNamedArray("tags");
                        for (uint o = 0; o < tags.Count; o++)
                        {
                            var tag = tags.GetObjectAt(o);

                            CsgoItem.Tag t = new Models.CsgoItem.Tag();
                            if (tag.ContainsKey("internal_name")) { t.Internal_name = tag.GetNamedString("internal_name"); }
                            if (tag.ContainsKey("name")) { t.Name = tag.GetNamedString("name"); }
                            if (tag.ContainsKey("category")) { t.Category = tag.GetNamedString("category"); }
                            if (tag.ContainsKey("color")) { t.Color = tag.GetNamedString("color"); }
                            if (tag.ContainsKey("category_name")) { t.Category_name = tag.GetNamedString("category_name"); }

                            skin.Tags.Add(t);
                        }
                    }

                    //JsonArray elementTags = element.GetNamedArray("tags");
                    //for (uint o = 0; o < elementTags.Count; o++)
                    //{
                    //    WeaponSkins.Tag tag = new WeaponSkins.Tag();
                    //    JsonObject tagObj = elementMarketActions.GetObjectAt(o);
                    //    tag.Internal_name = tagObj.GetNamedString("internal_name");
                    //    tag.Name = tagObj.GetNamedString("name");
                    //    tag.Category = tagObj.GetNamedString("category");
                    //    if (tagObj.ContainsKey("color"))
                    //    {
                    //        tag.Color = tagObj.GetNamedString("color");
                    //    }
                    //    tag.Category_name = tagObj.GetNamedString("category_name");
                    //}

                    #region nicht einheitliche Elemente

                    // hier müssen nocht if oder exceptions eingefügt werden, um zu verhindern, das das Objekt nicht gefunden werden kann

                    //JsonArray elementDes = element.GetNamedArray("descriptions");
                    //for (uint k = 0; k < elementDes.Count; k++)
                    //{
                    //    Description des = new Description();
                    //    JsonObject desObj = elementDes.GetObjectAt(k);
                    //    des.Type = desObj.GetNamedString("type");
                    //    des.Value = desObj.GetNamedString("value");
                    //    des.Color = desObj.GetNamedString("color");

                    //    JsonObject appData = desObj.GetNamedObject("app_data");
                    //    if (appData.ContainsKey("def_index)
                    //    {
                    //        des.App_data.Def_index = appData.GetNamedString("def_index");
                    //    }
                    //    //des.App_data.Def_index = appData.GetNamedString("def_index");
                    //    des.App_data.Is_Itemset_name = appData.GetNamedNumber("is_itemset_name");
                    //    des.App_data.Limited = appData.GetNamedNumber("limited");
                    //    skin.Descriptions.Add(des);
                    //}

                    //JsonArray elementActions = element.GetNamedArray("actions");
                    //for (uint l = 0; l < elementActions.Count; l++)
                    //{
                    //    WeaponSkins.Action act = new WeaponSkins.Action();
                    //    JsonObject actObj = elementDes.GetObjectAt(l);
                    //    act.Name = actObj.GetNamedString("name");
                    //    act.Link = actObj.GetNamedString("link");
                    //    skin.Actions.Add(act);                        
                    //}

                    //JsonArray elementMarketActions = element.GetNamedArray("market_actions");
                    //for (uint m = 0; m < elementMarketActions.Count; m++)
                    //{
                    //    WeaponSkins.MarketAction marAct = new WeaponSkins.MarketAction();
                    //    JsonObject actObj = elementMarketActions.GetObjectAt(m);
                    //    marAct.Name = actObj.GetNamedString("name");
                    //    marAct.Link = actObj.GetNamedString("link");
                    //}



                    #endregion

                }
            }
            #endregion

            #region inventoryString2

            //API funktioniert nicht mehr

            //JsonObject root2 = JsonObject.Parse(inventoryString2);
            //JsonObject result = root2.GetNamedObject("result");
            //double status = result.GetNamedNumber("status");
            //JsonArray items = result.GetNamedArray("items");
            //for (int i = 0; i < items.Count; i++)
            //{
            //    JsonObject itemObj = items.ElementAt(i).GetObject();
            //    var skinSel2 = from skins in SteamInventory where string.Equals(itemObj.GetNamedNumber("id").ToString(), skins.Id) select skins;
            //    WeaponSkin skin = skinSel2.First();
            //    JsonArray itemObjAttr = itemObj.GetNamedArray("attributes");
            //    for (int j = 0; j < itemObjAttr.Count; j++)
            //    {
            //        JsonObject Attribute = itemObjAttr.ElementAt(j).GetObject();
            //        if (Attribute.GetNamedNumber("defindex")==8&&Attribute.ContainsKey("float_value")) { skin.Float_value = Attribute.GetNamedNumber("float_value"); }       
            //    }     
            //}


            #endregion
        }

        public static string[] GetInventoryString()
        {
            string[] InventoryStrings = new string[2];
            InventoryStrings[0] = DataReceiver.GetInventoryString("http://steamcommunity.com/profiles/76561197988463243/inventory/json/730/2");
            //do
            //{
            //    InventoryStrings[2] = DataReceiver.GetInventoryString("http://api.steampowered.com/IEconItems_730/GetPlayerItems/v0001/?key=BD53E35BE3185B7BEE6E28B4564907B4&SteamID=76561197988463243");
            //} while (InventoryStrings[2].StartsWith("{\n\n}") || InventoryStrings[2].Length == 0);

            //for offline debugging:
            #region offline Strings

            //InventoryStrings[1] = FileIO.ReadTextAsync(StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Models/SteamInventory/Csgo/InventoryJson_1.txt")).GetAwaiter().GetResult()).GetAwaiter().GetResult();

            //InventoryStrings[2] = FileIO.ReadTextAsync(StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Models/SteamInventory/Csgo/InventoryJson_2.txt")).GetAwaiter().GetResult()).GetAwaiter().GetResult();

            return InventoryStrings;

            #endregion
        }

        public void GetInventoryIcons()
        {
            string IconUriBase = "http://steamcommunity-a.akamaihd.net/economy/image/";
            string IconUriString, IconLargeUriString;
            StorageFolder Folder = ApplicationData.Current.LocalFolder.CreateFolderAsync("Icons", CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();
            foreach (WeaponSkin skin in SteamInventory)
            {
                IconUriString = IconUriBase + skin.Icon_url;
                IconLargeUriString = IconUriBase + skin.Icon_url_large;
                
                skin.Icon = DataReceiver.DownloadImageAsync(Folder, IconUriString, skin.ClassId.ToString() + ".png").Result;
                skin.Icon_large = DataReceiver.DownloadImageAsync(Folder, IconUriString, skin.ClassId.ToString() + "_large" + ".png").Result;
            }
        }

        public void GetAllPriceData()
        {
            //Pro Minute können bei Steam nur die Preise für 20 Artikel angefragt werden, danach kommt eine Fehlermeldung
            foreach (WeaponSkin skin in SteamInventory)
            {
                skin.PriceCol.Insert(0, DataReceiver.GetMarketPriceoverview("3", skin.AppId, skin.Market_hash_name));
            }
        }

        public void GenerateInventory()
        {
            SteamInventory = new ObservableCollection<WeaponSkin>();

            InventorySteam64Id = ApplicationData.Current.LocalSettings.Values["Steam64Id"].ToString();

            ParseJsonInventory();
            
            GetInventoryIcons();

            //GetPriceData();
        }

    }
}
