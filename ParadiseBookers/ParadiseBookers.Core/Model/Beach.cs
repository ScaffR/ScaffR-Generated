using System.Data.Spatial;

namespace ParadiseBookers.Core.Model
{
    public class Beach : DomainObject
    {
        public DbGeography Location { get; set; }

        public string Name { get; set; }

        public bool Surfing { get; set; }

        public string Description { get; set; }

        public string SandType { get; set; }
    }
}