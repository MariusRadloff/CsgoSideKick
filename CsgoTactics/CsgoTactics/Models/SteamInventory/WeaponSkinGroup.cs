using CsgoTactics.Models.WeaponSkins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models.SteamInventory.Csgo
{
    public class WeaponSkinGroup : Object, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<WeaponSkin> invGroup;

        public ObservableCollection<WeaponSkin> InvGroup
        {
            get { return invGroup; }
            set { invGroup = value; }
        }

        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                NotifyPropertyChanged();
            }
        }

        private double groupItemCount;

        public double GroupItemCount
        {
            get { return groupItemCount; }
            set
            {
                groupItemCount = value;
                NotifyPropertyChanged();
            }
        }

        private string groupCsgoType;

        public string GroupCsgoType
        {
            get { return groupCsgoType; }
            set { groupCsgoType = value; }
        }

        public WeaponSkinGroup ShallowCopy()
        {
            return (WeaponSkinGroup)MemberwiseClone();
        }
    }
}

