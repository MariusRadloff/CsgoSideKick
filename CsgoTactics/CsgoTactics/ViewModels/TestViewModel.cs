using CsgoTactics.SteamInventory;
using CsgoTactics.Models.WeaponSkins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsgoTactics.SteamInventory.Csgg;
using CsgoTactics.DbDataAccess;
using DbModel;

namespace CsgoTactics.ViewModels
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            db = DbDataAccess.LinqDataAccess.getDb();
        }
        public InventoryDbContext db;
    }
}
