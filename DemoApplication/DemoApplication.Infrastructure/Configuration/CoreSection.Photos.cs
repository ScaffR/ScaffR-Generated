namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Photos;

    #endregion

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
