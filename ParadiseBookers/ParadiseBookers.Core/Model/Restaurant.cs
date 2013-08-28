using System.Data.Spatial;

namespace ParadiseBookers.Core.Model
{
    public class Restaurant : DomainObject
    {
        public string Name { get; set; }
        public DbGeography Location { get; set; }
    
        // type of food (mexican, italian, etc)
        public string Category { get; set; }

        public string Hours { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }
    }
}