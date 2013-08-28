using System.Data.Spatial;

namespace ParadiseBookers.Core.Model
{
    public class Attraction : DomainObject
    {
        public DbGeography Location { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AttractionType Type { get; set; }

        public string Price { get; set; }
    }
}