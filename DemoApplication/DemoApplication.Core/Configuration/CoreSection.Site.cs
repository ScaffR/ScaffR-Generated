namespace DemoApplication.Core.Configuration
{
    using System.Configuration;
    using Site;

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
