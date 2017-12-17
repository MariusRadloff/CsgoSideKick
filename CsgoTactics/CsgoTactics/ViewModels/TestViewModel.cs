using CsgoTactics.SteamInventory;
using CsgoTactics.Models.WeaponSkins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsgoTactics.SteamInventory.Csgg;

namespace CsgoTactics.ViewModels
{
    public class TestViewModel
    {
        public ObservableCollection<WeaponSkin> skins = new ObservableCollection<WeaponSkin>();
        public WeaponSkin skin1 = new WeaponSkin();
        //public Skin skin2 = new Skin();

        public async Task getSkins()
        {
            Task<ObservableCollection<WeaponSkin>> getSkinTask = SkinReceiver.GetSkins();

            skins = await getSkinTask;

            skin1 = skins[0];
            
        }

        private async Task<ObservableCollection<WeaponSkin>> getSkins2()
        {
            return await SkinReceiver.GetSkins();
        }
    }
}
