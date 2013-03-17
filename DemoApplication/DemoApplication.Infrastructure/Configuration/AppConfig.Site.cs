namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Site;

    #endregion

    public partial class AppConfig
    {
        [ConfigurationProperty("site", IsRequired = true)]
        public SiteElement Site
        {
            get
            {
                return (SiteElement)base["site"];
            }
        }
    }
}
