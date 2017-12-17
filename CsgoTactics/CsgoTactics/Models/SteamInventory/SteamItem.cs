using CsgoTactics.WebServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace CsgoTactics.Models.SteamInventory
{
    public class SteamItem : Object, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Eigenschaften, die durch die Api ( "http://steamcommunity.com/profiles/76561197988463243/inventory/json/730/2" ) abgerufen und gespeichert werden.

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string classId;

        public string ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

        private string instanceId;

        public string InstanceId
        {
            get { return instanceId; }
            set { instanceId = value; }
        }

        private string amount;

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private double pos;

        public double Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        // Eigenschaft für den Preis des Steam-Community-Markts

        private ObservableCollection<SteamPrice> priceCol;

        public ObservableCollection<SteamPrice> PriceCol
        {
            get { return priceCol; }
            set
            {
                priceCol = value;
                NotifyPropertyChanged();
            }
        }

        private PurchaseData buyPrice;

        public PurchaseData BuyPrice
        {
            get { return buyPrice; }
            set
            {
                buyPrice = value;
                NotifyPropertyChanged();
            }
        }



        // Eigene Eigenschaft, die ermittelt werden muss. z.B. Aus AppId

        private SteamItemTypes steamItemType;

        public SteamItemTypes SteamItemType
        {
            get { return steamItemType; }
            set { steamItemType = value; }
        }

        public enum SteamItemTypes
        {
            GameItem,
            SteamItem
        }

        public class PurchaseData
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private string price;

            public string Price
            {
                get { return price; }
                set
                {
                    price = value;
                    NotifyPropertyChanged();
                }
            }

            private DateTime date;

            public DateTime Date
            {
                get { return date; }
                set
                {
                    date = value;
                    NotifyPropertyChanged();
                }
            }


        }

        public class SteamPrice
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public SteamPrice()
            {
                MarketMedianPrice = "N.a.";
                MarketLowestPrice = "N.a.";
                MarketVolume = "N.a.";
                
            }

            public SteamPrice(string median, string lowest, string amount, DateTime date)
            {
                MarketMedianPrice = median;
                MarketLowestPrice = lowest;
                MarketVolume = amount;
                DatePrice = date;
            }

            private string marketMedianPrice;

            public string MarketMedianPrice
            {
                get { return marketMedianPrice; }
                set
                {
                    marketMedianPrice = value;
                    NotifyPropertyChanged();
                }
            }

            private string marketLowestPrice;

            public string MarketLowestPrice
            {
                get { return marketLowestPrice; }
                set
                {
                    marketLowestPrice = value;
                    NotifyPropertyChanged();
                }
            }

            private string marketVolume;

            public string MarketVolume
            {
                get { return marketVolume; }
                set
                {
                    marketVolume = value;
                    NotifyPropertyChanged();

                }
            }

            private DateTime datePrice;

            public DateTime DatePrice
            {
                get { return datePrice; }
                set
                {
                    datePrice = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
