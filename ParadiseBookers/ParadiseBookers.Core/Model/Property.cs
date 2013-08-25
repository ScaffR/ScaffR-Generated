using System.ComponentModel;
using System.Data.Spatial;

namespace ParadiseBookers.Core.Model
{
    public enum PoolType
    {
        [Description("No Pool")]
        None,

        [Description("Shared Pool")]
        Shared,

        [Description("Private Pool")]
        Private
    }

    public enum FurninishingType
    {
        NotFurnished,

        FullyFurnished
    }

    public class Property : DomainObject
    {
        public string Name { get; set; }

        public DbGeography Location { get; set; }

        public int BedRooms { get; set; }

        public int BathRooms { get; set; }

        public int Sleeps { get; set; }

        public bool PetsAllowed { get; set; }

        public bool CableTv { get; set; }

        public bool DvdPlayer { get; set; }

        public PoolType Pool { get; set; }

        public int FloorArea { get; set; }

        // kitchen stuff
        public bool FullKitchen { get; set; }

        public bool Refrigerator { get; set; }

        public bool CoffeeMaker { get; set; }

        public bool Microwave { get; set; }

        public bool Cookware { get; set; }

        public bool Dishwasher { get; set; }

        public bool Oven { get; set; }

        // living stuff
        public bool CentralAir { get; set; }

        public bool CeilingFans { get; set; }

        public bool Linens { get; set; }

        public bool WasherAndDryer { get; set; }

        public bool Wifi { get; set; }

        public bool TwentyFourSecurity { get; set; }

        public bool Elevator { get; set; }

        public bool Towels { get; set; }

        public bool Phone { get; set; }

        public FurninishingType Furninishing { get; set; }

        // location stuff
        public bool BeachNearby { get; set; }

        public int BeachDistanceMiles { get; set; }
    }
}
