using System.Data.Spatial;
using ParadiseBookers.Core.Common.Geography;
using ParadiseBookers.Models.Common;

namespace ParadiseBookers.Models.Beaches
{
    public class BeachViewModel
    {
        public BeachViewModel()
        {
            // some sample change
            Location = new AddressModel()
            {
                Address = "301 15th Street, Hood River",
                Location = GeographyHelpers.CreatePoint(45.7120903, -121.5272902)
            };
        }

        public AddressModel Location { get; set; }

        public string Name { get; set; }

        public bool Surfing { get; set; }

        public string Description { get; set; }

        public string SandType { get; set; }
    }
}
