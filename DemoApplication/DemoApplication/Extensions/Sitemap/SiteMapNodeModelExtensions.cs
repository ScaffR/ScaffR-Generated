using System;

namespace DemoApplication.Extensions.Sitemap
{
    using System.Web.Mvc;
    using MvcSiteMapProvider.Web.Html.Models;

    public static class SiteMapNodeModelExtensions
    {
        public static bool IsActiveNode(this SiteMapNodeModel model, ViewContext context)
        {
            bool isRootNode = model.IsRootNode;
            bool isCurrentPath = model.IsInCurrentPath;
            bool isCurrentNode = (context.Controller.ValueProvider.GetValue("action").RawValue.ToString().Equals(model.Action, StringComparison.CurrentCultureIgnoreCase)
                                 && context.Controller.ValueProvider.GetValue("controller").RawValue.ToString().Equals(model.Controller, StringComparison.InvariantCultureIgnoreCase));

            if (isCurrentNode)
            {
                return true;
            }
                

            if (isCurrentPath && !isRootNode)
            {
                return true;
            }

            return false;
        }
    }
}