#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
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