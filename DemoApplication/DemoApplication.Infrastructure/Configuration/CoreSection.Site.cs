namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Site;

    #endregion

    public partial class CoreSection
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
