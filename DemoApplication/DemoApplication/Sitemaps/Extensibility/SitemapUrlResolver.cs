namespace DemoApplication.Sitemaps.Extensibility
{
    #region

    using System.Collections.Generic;
    using MvcSiteMapProvider;

    #endregion

    public class SitemapUrlResolver : DefaultSiteMapNodeUrlResolver
    {
        public override string ResolveUrl(MvcSiteMapNode mvcSiteMapNode, string area, string controller, string action, IDictionary<string, object> routeValues)
        {
            return base.ResolveUrl(mvcSiteMapNode, area, controller, action, routeValues).ToLower();
        }
    }
}