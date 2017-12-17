using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{

    // Klasse, um die verschiedenen Fixpunktgranaten mit ihren Eigenschaften speichern zu können.

    public class GrenadeThrow
    {
        public GrenadeThrow()
        {

        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private MapName map;

        public MapName Map
        {
            get { return map; }
            set { map = value; }
        }

        private string throwLocation;

        public string ThrowLocation
        {
            get { return throwLocation; }
            set { throwLocation = value; }
        }

        private string grenadeDestination;

        public string GrenadeDestination
        {
            get { return grenadeDestination; }
            set { grenadeDestination = value; }
        }

        private GrenadeType nadeType;

        public GrenadeType NadeType
        {
            get { return nadeType; }
            set { nadeType = value; }
        }

        private VerticalMovement vertMovement;

        public VerticalMovement VertMovement
        {
            get { return vertMovement; }
            set { vertMovement = value; }
        }

        private HorizontalMovement horMovementType;

        public HorizontalMovement HorMovementType
        {
            get { return horMovementType; }
            set { horMovementType = value; }
        }

        private ThrowStrength strength;

        public ThrowStrength Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public enum ThrowStrength { low, medium, high };
        public enum VerticalMovement { jump, noJump };
        public enum HorizontalMovement { stand, go, runn };
        public enum GrenadeType { Flashbang, Smoke, HE, Molotov, Decoi}
        public enum MapName { Dust_2, Inferno, Nuke, Mirage, Cache, Cobblestone, Overpass }
    }
}
