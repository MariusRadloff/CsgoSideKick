using CsgoTactics.Models.SteamInventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace CsgoTactics.Models
{
    public class CsgoItem : SteamItem , INotifyPropertyChanged
    {
        //PropertyChanged (noch) nicht impelementiert
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        #region Constructor
        public CsgoItem(string id)
        {
            Id = id;
        }

        public CsgoItem()
        {
            Id = "";
        }
        #endregion

        #region Properties
        private string appId;

        public string AppId
        {
            get { return appId; }
            set { appId = value; }
        }

        private string icon_url;

        public string Icon_url
        {
            get { return icon_url; }
            set { icon_url = value; }
        }

        private string icon_url_large;

        public string Icon_url_large
        {
            get { return icon_url_large; }
            set { icon_url_large = value; }
        }

        private string icon_drag_url;

        public string Icon_drag_url
        {
            get { return icon_drag_url; }
            set { icon_drag_url = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string market_hash_name;

        public string Market_hash_name
        {
            get { return market_hash_name; }
            set { market_hash_name = value; }
        }

        private string market_name;

        public string Market_name
        {
            get { return market_name; }
            set { market_name = value; }
        }

        private string name_color;

        public string Name_color
        {
            get { return name_color; }
            set
            {
                if (value.Substring(0, 3) == "#FF")
                {
                    name_color = value;
                }
                else
                {
                    name_color = "#FF" + value;
                }
            }
        }

        private string background_color;

        public string Background_color
        {
            get { return background_color; }
            set { background_color = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private double tradable;

        public double Tradable
        {
            get { return tradable; }
            set { tradable = value; }
        }

        private double marketable;

        public double Marketable
        {
            get { return marketable; }
            set { marketable = value; }
        }

        private double commodity;

        public double Commodity
        {
            get { return commodity; }
            set { commodity = value; }
        }

        private string market_tradable_restriction;

        public string Market_tradable_restriction
        {
            get { return market_tradable_restriction; }
            set { market_tradable_restriction = value; }
        }


        private List<Description> descriptions;

        public List<Description> Descriptions
        {
            get { return descriptions; }
            set { descriptions = value; }
        }

        private List<Action> actions;

        public List<Action> Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        private List<MarketAction> market_actions;

        public List<MarketAction> Market_actions
        {
            get { return market_actions; }
            set { market_actions = value; }
        }

        private List<Tag> tags;

        public List<Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        //Url to download the picture of the skin
        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        //Picture of the skin from the Url
        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private string icon_large;

        public string Icon_large
        {
            get { return icon_large; }
            set { icon_large = value; }
        }


        //Aus file mit float-value

        private double float_value;

        public double Float_value
        {
            get { return float_value; }
            set { float_value = value; }
        }

        private CsgoItemTypes csgoItemType;

        public CsgoItemTypes CsgoItemType
        {
            get { return csgoItemType; }
            set { csgoItemType = value; }
        }
        #endregion

        #region Support-Classes
        public class Description
        {
            public Description() { }
            public Description(string type, string _value, string color)
            {
                this.type = type;
                this._value = _value;
                this.color = color;
            }
            public Description(string type, string _value, string color, App_data app_data)
            {
                this.type = type;
                this._value = _value;
                this.color = color;
                this.app_data = app_data;
            }

            private string type;

            public string Type
            {
                get { return type; }
                set { type = value; }
            }

            private string _value;

            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }

            private string color;

            public string Color
            {
                get { return color; }
                set
                {
                    if (value != null)
                    {
                        if (value.Substring(0, 3) == "#FF")
                        {
                            color = value;
                        }
                        else
                        {
                            color = "#FF" + value;
                        }
                    }

                }
            }

            private App_data app_data;

            public App_data App_data
            {
                get { return app_data; }
                set { app_data = value; }
            }


        }
        public class App_data
        {
            private string def_index;

            public string Def_index
            {
                get { return def_index; }
                set { def_index = value; }
            }

            private double is_Itemset_name;

            public double Is_Itemset_name
            {
                get { return is_Itemset_name; }
                set { is_Itemset_name = value; }
            }

            private double limited;

            public double Limited
            {
                get { return limited; }
                set { limited = value; }
            }


        }

        public class Action
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string link;

            public string Link
            {
                get { return link; }
                set { link = value; }
            }

        }

        public class MarketAction
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string link;

            public string Link
            {
                get { return link; }
                set { link = value; }
            }

        }

        public class Tag
        {
            private string internal_name;

            public string Internal_name
            {
                get { return internal_name; }
                set { internal_name = value; }
            }

            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string category;

            public string Category
            {
                get { return category; }
                set { category = value; }
            }

            private string color;

            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            private string category_name;

            public string Category_name
            {
                get { return category_name; }
                set { category_name = value; }
            }
        }
        #endregion

        #region Enums
        public enum CsgoItemTypes
        {
            Case,
            GiftPackage,
            Key,
            MusicKit,
            NameTag,
            OperationPass,
            Pin,
            WeaponSkin,
            Sticker,
            Capsule
        }
        #endregion
    }
}
