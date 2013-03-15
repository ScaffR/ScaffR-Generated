using System.Collections.Generic;

namespace DemoApplication.Sitemaps.Extensibility
{
    using MvcSiteMapProvider;

    public class SitemapUrlResolver : DefaultSiteMapNodeUrlResolver
    {
        public override string ResolveUrl(MvcSiteMapNode mvcSiteMapNode, string area, string controller, string action, IDictionary<string, object> routeValues)
        {
            return base.ResolveUrl(mvcSiteMapNode, area, controller, action, routeValues).ToLower();
        }
    }
}