using System.Configuration;
using ParadiseBookers.Infrastructure.Configuration.Storage;

namespace ParadiseBookers.Infrastructure.Configuration
{
    public partial class AppConfig
    {
        [ConfigurationProperty("storage", IsRequired = true)]
        public StorageElement Storage
        {
            get
            {
                return (StorageElement)base["storage"];
            }
        }
    }
}
