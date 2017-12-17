using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CsgoTactics.ViewModels
{
    public class OptionsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        private string optSteam64Id;

        public string OptSteam64Id
        {
            get
            {
                try
                {
                    optSteam64Id = localSettings.Values["Steam64Id"].ToString();
                }
                catch (Exception)
                {
                    optSteam64Id = "";
                }
                return optSteam64Id;
            }
            set
            {
                optSteam64Id = value;
                localSettings.Values["Steam64Id"] = value;
                NotifyPropertyChanged();
                calcLinks();
            }
        }

        private string optApiKey;


        public string OptApiKey
        {
            get
            {
                try
                {
                    optApiKey = localSettings.Values["ApiKey"].ToString();
                }
                catch (Exception)
                {
                    optApiKey = "";
                }
                
                return optApiKey;
            }
            set
            {
                optApiKey = value;
                localSettings.Values["ApiKey"] = value;
                NotifyPropertyChanged();
                calcLinks();
            }
        }

        private string optInventoryLink;

        public string OptInventoryLink
        {
            get
            {
                try
                {
                    optInventoryLink = localSettings.Values["InventoryLink"].ToString();
                }
                catch (Exception)
                {
                    optInventoryLink = "";
                }
                return optInventoryLink;
            }
            set
            {
                optInventoryLink = value;
                localSettings.Values["InventoryLink"] = value;
                NotifyPropertyChanged();
            }
        }

        private string optItemsLink;

        public string OptItemsLink
        {
            get
            {
                try
                {
                    optItemsLink = localSettings.Values["ItemsLink"].ToString();
                }
                catch (Exception)
                {
                    optItemsLink = "";
                }
                return optItemsLink;
            }
            set
            {
                optItemsLink = value;
                localSettings.Values["ItemsLink"] = value;
                NotifyPropertyChanged();
            }
        }

        public void calcLinks()
        {
            if (OptSteam64Id != "" && OptApiKey != "")
            {
                OptItemsLink = "http://api.steampowered.com/IEconItems_730/GetPlayerItems/v0001/?key=" + OptApiKey + "&SteamID=" + OptSteam64Id;
            }
            else
            {
                OptItemsLink = "Steam64Id und Api-Key wird benötigt";
            }

            if (OptSteam64Id != "")
            {
                OptInventoryLink = "http://steamcommunity.com/profiles/" + OptSteam64Id + "/inventory/json/730/2";

            }
            else
            {
                OptInventoryLink = "Steam64Id wird benötigt";
            }
        }
    }
}
