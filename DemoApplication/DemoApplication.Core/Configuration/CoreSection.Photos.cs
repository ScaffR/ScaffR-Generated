namespace DemoApplication.Core.Configuration
{
    using System.Configuration;
    using Photos;

    public partial class CoreSection
    {
        [ConfigurationProperty("photos", IsRequired = true)]
        public PhotoConfigurationElement Photos
        {
            get
            {
                return (PhotoConfigurationElement)base["photos"];
            }
        }
    }
}
