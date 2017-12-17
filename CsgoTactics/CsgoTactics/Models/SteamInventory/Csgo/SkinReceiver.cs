using CsgoTactics.Models;
using CsgoTactics.Models.WeaponSkins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;

namespace CsgoTactics.SteamInventory.Csgg
{
    //Class to get a List of all the skins with the pictures and Names (links are located in csgo file "\SteamLibrary\steamapps\common\Counter-Strike Global Offensive\csgo\scripts\items\items_game_cdn.txt"
    public static class SkinReceiver
    {
        public static async Task<ObservableCollection<WeaponSkin>> GetSkins()
        {
            //Collection of the skins
            ObservableCollection<WeaponSkin> SkinCollection = new ObservableCollection<WeaponSkin>();

            //CSGO-File where the URIs are stored in
            StorageFile inputFile = await GetSkinsFileAsync();

            //Saves the text of the inputFile in a string for further editing
            string text = await Windows.Storage.FileIO.ReadTextAsync(inputFile);

            //erases all entries in the text before the first url
            if (!text.StartsWith("weapon"))
            {
                text = text.Substring(text.IndexOf("weapon"));
            }
            
            //downloading the pictures from the different urls
            while (text.Length != 0)
            {
                WeaponSkin skin = new WeaponSkin();
                skin.Id = text.Substring(0, text.IndexOf("="));
                text = text.Substring(text.IndexOf("=") + 1);
                skin.Url = text.Substring(0, text.IndexOf("\r\n"));
                text = text.Substring(text.IndexOf("\n") + 1);
                try
                {
                    //downloading the pictures from the urls
                    Uri sourceUri = new Uri("ms-appx:///Images/WeaponSkins/defaultSkin.png");

                    string destination = "ms-appx:///Images/WeaponSkins/" + skin.Id + ".png";

                    //getting the destination Folder for the pictures, by receiving the parent folder from a default file
                    StorageFile defaultFile = await StorageFile.GetFileFromApplicationUriAsync(sourceUri);                  
                    Windows.Storage.StorageFolder storageFolder = await defaultFile.GetParentAsync();

                    //creating the .png file for the picture
                    Windows.Storage.StorageFile destinationFile = await storageFolder.CreateFileAsync(skin.Id + ".png", Windows.Storage.CreationCollisionOption.ReplaceExisting);

                    //StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(destination, CreationCollisionOption.GenerateUniqueName);

                    //downloading the picture from the url
                    BackgroundDownloader downloader = new BackgroundDownloader();
                    DownloadOperation download = downloader.CreateDownload(new Uri(skin.Url), destinationFile);

                    // Attach progress and completion handlers.
                    var result = download.StartAsync();

                    //assign the downloaded picture to the skin
                    skin.Icon = destinationFile.Path;
                }
                catch (Exception ex)
                {
                    //LogException("Download Error", ex);
                }
                //adding the skin to the collection
                SkinCollection.Add(skin);
            }
            return SkinCollection;
        }

        //Task: replace, witch automatic file search, without file picker
        public static async Task<StorageFile> GetSkinsFileAsync()
        {
            StorageFile inputFile;

            if (/*rootPage.EnsureUnsnapped()*/true)
            {
                // open the csgo file "\SteamLibrary\steamapps\common\Counter-Strike Global Offensive\csgo\scripts\items\items_game_cdn.txt"
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.FileTypeFilter.Add(".txt");

                // Folder Picker funktioniert nicht, da man in UWP nicht auf alle Pfade zugreifen darf.
                // Mit dem FilePicker funktioniert es, da so die Rechte am verwenden der Datei durch den user gegeben werden.

                //FolderPicker folderPicker = new FolderPicker();
                //folderPicker.ViewMode = PickerViewMode.List;
                //folderPicker.FileTypeFilter.Add("*");     

                //StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                //string pathStart = folder.Path;
                //string pathEnd = Path.Combine("scripts", "items", "items_game_cdn.txt");
                //string path = Path.Combine(pathStart, pathEnd);
                                
                //inputFile = await StorageFile.GetFileFromPathAsync(path);
                inputFile = await openPicker.PickSingleFileAsync();

                if (inputFile != null)
                {
                    // Application now has read/write access to the picked file
                    //OutputTextBlock.Text = "Picked photo: " + inputFile.Name;
                }
                else
                {
                    //OutputTextBlock.Text = "Operation cancelled.";
                }
            }
            return inputFile;
        }

    }
}