using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Common
{
    class LiveDataEnums
    {
        enum DataType
        {
            Items,
            Score,
        }

        enum ItemsType
        {
            Weapon,
            Armor,
            Bomb
        }

        #region Weapon
        enum WeaponType
        {
            Primary,
            Secondary,
            Melee,
            Grenade,
            Equipment,
        }

        enum Primary
        {
            Heavy,
            Smg,
            Rifle,
        }

        enum Secondary
        {
            Pistol
        }

        enum Melee
        {
            Knife
        }

        enum Grenade
        {
            Flashbang,
            HeGrenade,
            SmokeGrenade,
            Molotov,
            Incendiary,
            Decoy,
        }

        enum Equipment
        {
            Taser
        }
        #endregion


        enum ArmorType
        {
            Kevlar,
            Helmet
        }

        enum BombType
        {
            C4,
            DefuseKit,
        }
    }
}
