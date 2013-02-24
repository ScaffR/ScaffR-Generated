namespace DemoApplication.Extensions.Html
{
    using System.Web;
    using System;
    using System.Web.Mvc;
    using Core.Common.Site;

    public static partial class HtmlExtensions
    {
        public static string GetPageTitle(this HtmlHelper helper)
        {
            try
            {
                if (SiteMap.CurrentNode != null)
                {
                    return Site.Instance.WebsiteName +  " - " + SiteMap.CurrentNode.Title;
                }
            }
            catch (Exception)
            {
                // do nothing
            }

            return Site.Instance.WebsiteName + " - " + helper.ViewBag.Title;
        }
    }
}