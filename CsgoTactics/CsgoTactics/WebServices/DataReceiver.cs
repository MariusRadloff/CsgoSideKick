using CsgoTactics.Models.WeaponSkins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using static CsgoTactics.Models.SteamInventory.SteamItem;

namespace CsgoTactics.WebServices
{
    static class DataReceiver
    {
        //public StorageFile DestinationFile;
        //public Uri InventoryWebUri, InventoryFileUri;

        //ObservableCollection<Skin> Inventory = new ObservableCollection<Skin>();

        //String Text = "";

        //bool isSuccess = false;


        public static string GetInventoryString(string uri)
        {
            Uri InventoryWebUri, InventoryFileUri;

            Uri.TryCreate(uri, UriKind.Absolute, out InventoryWebUri);

            Uri.TryCreate("ms-appx:///Models/SteamInventory/Csgo/InventoryJson.txt", UriKind.Absolute, out InventoryFileUri);

            //DestinationFile = await StorageFile.GetFileFromApplicationUriAsync(InventoryFileUri);

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            //Windows.Web.Http.HttpClient client2 = new Windows.Web.Http.HttpClient();

            System.Net.Http.HttpResponseMessage response = client.GetAsync(InventoryWebUri).Result;

            //Windows.Web.Http.HttpResponseMessage response2 = await client2.GetAsync(InventoryWebUri);

            String inventoryString = response.Content.ReadAsStringAsync().Result;

            //String str2 = await response2.Content.ReadAsStringAsync();

            return inventoryString;
        }

        public static async Task<string> DownloadImageAsync(StorageFolder folder, string url, string fileName)
        {
            bool fileExists = File.Exists(folder.Path + "\\" + fileName);

            if (fileExists)
            {
                return folder.GetFileAsync(fileName).GetAwaiter().GetResult().Path;
            }
            else
            {
                //Open a connection
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

                //Set timeout for 20 seconds
                httpWebRequest.ContinueTimeout = 20000;

                //Request response
                WebResponse webResponse = httpWebRequest.GetResponseAsync().GetAwaiter().GetResult();

                //Open data stream
                Stream webStream = webResponse.GetResponseStream();


                StorageFile IconFile = folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();

                Stream IconFileStream = IconFile.OpenStreamForWriteAsync().GetAwaiter().GetResult();

                webStream.CopyTo(IconFileStream);

                IconFileStream.Dispose();


                //var request = WebRequest.CreateHttp(url);
                //var donnetClient = new System.Net.Http.HttpClient();
                //var winrtClient = new Windows.Web.Http.HttpClient();

                //BackgroundDownloader downloader = new BackgroundDownloader();

                //Uri uri;

                //Uri.TryCreate(url, UriKind.Absolute, out uri);

                //DownloadOperation download = downloader.CreateDownload(uri, IconFile);

                //await download.StartAsync();

                return IconFile.Path;
            }
        }

        public static SteamPrice GetMarketPriceoverview(string currency, string appId, string market_hash_name)
        {
            Uri PriceOverviewUri;

            Uri.TryCreate("http://steamcommunity.com/market/priceoverview/?currency=" + currency + "&appid=" + appId + "&market_hash_name=" + market_hash_name, UriKind.Absolute, out PriceOverviewUri);

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            try
            {
                System.Net.Http.HttpResponseMessage response = client.GetAsync(PriceOverviewUri).Result;
                string priceString = response.Content.ReadAsStringAsync().Result;

                JsonObject priceJson;
                JsonObject.TryParse(priceString, out priceJson); // 3 for Euro as currency

                SteamPrice price = new SteamPrice();

                if (priceJson.ContainsKey("success"))
                {
                    if (priceJson.GetNamedBoolean("success"))
                    {
                        if (priceJson.ContainsKey("median_price")) { price.MarketMedianPrice = priceJson.GetNamedString("median_price"); }
                        if (priceJson.ContainsKey("volume")) { price.MarketVolume = priceJson.GetNamedString("volume"); }
                        if (priceJson.ContainsKey("lowest_price")) { price.MarketLowestPrice = priceJson.GetNamedString("lowest_price"); }
                        price.DatePrice = DateTime.Now;
                    }
                }

                return price;
            }
            catch (Exception e)
            {
                return null;
            }
            


        }

        public static SteamPrice GetMarketPricehistory(string currency, string appId, string market_hash_name)
        {
            Uri PriceOverviewUri;

            Uri.TryCreate("http://steamcommunity.com/market/pricehistory/?country=DE&currency=" + currency + "&appid=" + appId + "&market_hash_name=" + market_hash_name, UriKind.Absolute, out PriceOverviewUri);

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            System.Net.Http.HttpResponseMessage response = client.GetAsync(PriceOverviewUri).Result;

            string priceString = response.Content.ReadAsStringAsync().Result;

            JsonObject priceJson;
            JsonObject.TryParse(priceString, out priceJson); // 3 for Euro as currency

            SteamPrice price = new SteamPrice();

            if (priceJson.ContainsKey("success"))
            {
                if (priceJson.GetNamedBoolean("success"))
                {
                    if (priceJson.ContainsKey("price_prefix")) { price.MarketMedianPrice = priceJson.GetNamedString("median_price"); }
                    if (priceJson.ContainsKey("price_suffix")) { price.MarketVolume = priceJson.GetNamedString("volume"); }
                    if (priceJson.ContainsKey("prices")) { price.MarketLowestPrice = priceJson.GetNamedString("lowest_price"); }
                    price.DatePrice = DateTime.Now;
                }
            }

            return price;
        }
    }
}
