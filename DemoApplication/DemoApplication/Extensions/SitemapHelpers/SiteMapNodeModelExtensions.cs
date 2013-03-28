#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.SitemapHelpers
{
    #region

    using System.Web.Mvc;
    using MvcSiteMapProvider.Web.Html.Models;

    #endregion

    public static class SiteMapNodeModelExtensions
    {
        public static bool IsActiveNode(this SiteMapNodeModel model, ViewContext context)
        {
            bool isRootNode = model.IsRootNode;
            bool isCurrentPath = model.IsInCurrentPath;
            bool isCurrentNode = model.IsCurrentNode;
            
            //bool isCurrentNode = (context.Controller.ValueProvider.GetValue("action").RawValue.ToString().Equals(model.Action, StringComparison.CurrentCultureIgnoreCase)
            //                     && context.Controller.ValueProvider.GetValue("controller").RawValue.ToString().Equals(model.Controller, StringComparison.InvariantCultureIgnoreCase));

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