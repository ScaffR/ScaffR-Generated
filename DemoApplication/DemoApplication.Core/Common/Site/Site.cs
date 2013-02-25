namespace DemoApplication.Core.Common.Site
{
    using Configuration;
    using Configuration.Site;

    public partial class Site
    {
        public static Site Instance
        {
            get
            {
                return new Site(CoreSection.GetConfig().Site);
            }
        }

        private readonly SiteElement _config;

        public Site(SiteElement config)
        {
            _config = config;
        }

        public string WebsiteName
        {
            get { return _config.WebsiteName; }
        }

        public string EmailAddress
        {
            get { return _config.EmailAddress; }
        }
    }
}