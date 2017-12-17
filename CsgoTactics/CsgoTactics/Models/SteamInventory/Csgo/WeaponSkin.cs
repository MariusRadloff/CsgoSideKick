using CsgoTactics.Models.SteamInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace CsgoTactics.Models.WeaponSkins
{
    public class WeaponSkin : CsgoItem
    {
        public WeaponSkin ShallowCopy()
        {
            return (WeaponSkin)MemberwiseClone();
        }





    }
}
