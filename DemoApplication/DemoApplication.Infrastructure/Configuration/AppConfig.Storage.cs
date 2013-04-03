using System.Configuration;
using DemoApplication.Infrastructure.Configuration.Storage;

namespace DemoApplication.Infrastructure.Configuration
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
