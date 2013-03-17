namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Photos;

    #endregion

    public partial class AppConfig
    {
        [ConfigurationProperty("photos", IsRequired = true)]
        public PhotoElement Photos
        {
            get
            {
                return (PhotoElement)base["photos"];
            }
        }
    }
}
