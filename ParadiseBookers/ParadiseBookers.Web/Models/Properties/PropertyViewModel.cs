using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;
using ParadiseBookers.Core.Common.Geography;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Dropdowns.Attributes;
using ParadiseBookers.Models.Common;

namespace ParadiseBookers.Models.Properties
{
    public class PropertyViewModel
    {
        public PropertyViewModel()
        {
            Location = new AddressModel()
                {
                    Address = "301 15th Street, Hood River",
                    Location = GeographyHelpers.CreatePoint(45.7120903, -121.5272902)
                };
        }

        public string Name { get; set; }

        public AddressModel Location { get; set; }

        [Display(Name = "Bedrooms")]
        public int BedRooms { get; set; }

        [Display(Name = "Bathrooms")]
        public int BathRooms { get; set; }

        [Display(Name = "Sleeps")]
        public int Sleeps { get; set; }

        [Display(Name = "Pets Allowed?")]
        public bool PetsAllowed { get; set; }

        [Display(Name = "Cable TV?")]
        public bool CableTv { get; set; }

        [Display(Name = "DVD Player?")]
        public bool DvdPlayer { get; set; }

        [Display(Name = "Pool?")]
        [EnumDropDown(typeof(PoolType))]
        public PoolType Pool { get; set; }

        public int FloorArea { get; set; }

        // kitchen stuff
        [Display(Name = "Full Kitchen?")]
        public bool FullKitchen { get; set; }

        [Display(Name = "Refrigerator")]
        public bool Refrigerator { get; set; }

        [Display(Name = "Refrigerator")]
        public bool CoffeeMaker { get; set; }

        public bool Microwave { get; set; }

        public bool Cookware { get; set; }

        public bool Dishwasher { get; set; }

        public bool Oven { get; set; }

        // living stuff
        [Display(Name = "Central Air")]
        public bool CentralAir { get; set; }

        [Display(Name = "Ceiling Fans")]
        public bool CeilingFans { get; set; }

        public bool Linens { get; set; }

        [Display(Name = "Washer And Dryer?")]
        public bool WasherAndDryer { get; set; }

        public bool Wifi { get; set; }

        [Display(Name = "24/7 Security")]
        public bool TwentyFourSecurity { get; set; }

        [Display(Name = "Elevator")]
        public bool Elevator { get; set; }

        [Display(Name = "Towels")]
        public bool Towels { get; set; }

        [Display(Name = "Phone")]
        public bool Phone { get; set; }

        [EnumDropDown(typeof(FurninishingType))]
        public FurninishingType Furninishing { get; set; }

        // location stuff
        [Display(Name = "Beach Nearby?")]
        public bool BeachNearby { get; set; }

        [Display(Name = "Beach Distance (Miles)")]
        public int BeachDistanceMiles { get; set; }
    }
}