#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Sitemaps.Extensibility
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using MvcSiteMapProvider;
    using MvcSiteMapProvider.Extensibility;
    using Security.Authorization;

    #endregion

    public class SitemapVisiblityProvider : ISiteMapNodeVisibilityProvider
    {
        private MethodInfo GetRequestedAction(MvcSiteMapNode mvcNode)
        {
            var resolver = new DefaultControllerTypeResolver();
            var controllerType = resolver.ResolveControllerType(mvcNode.Area, mvcNode.Controller);

            var methods =
                controllerType.GetMethods().Where(
                    w => w.Name.Equals(mvcNode.Action, StringComparison.CurrentCultureIgnoreCase));

            MethodInfo theMethod = null;

            foreach (var method in methods)
            {
                var principalSecurity =
                    method.GetCustomAttributes<ClaimsAuthorizeAttribute>().FirstOrDefault();

                var getAttr = method.GetCustomAttribute<HttpGetAttribute>();

                // if this is for the GET request and there is security flag, this is likely the correct action method
                if (getAttr != null && principalSecurity != null)
                {
                    theMethod = method;
                    break;
                }

                // if there is no method chose, but there is security, this is probably it
                if (theMethod == null && principalSecurity != null)
                {
                    theMethod = method;
                }
            }

            return theMethod;
        }

        public bool IsVisible(SiteMapNode node, HttpContext context, IDictionary<string, object> sourceMetadata)
        {
            bool isVisible = true;
            var mvcNode = node as MvcSiteMapNode;
            if (mvcNode != null && mvcNode.Action.Length > 0)
            {
                var theMethod = GetRequestedAction(mvcNode);

                if (theMethod != null)
                {
                    var principalSecurity =
                        theMethod.GetCustomAttributes<ClaimsAuthorizeAttribute>().FirstOrDefault();

                    if (principalSecurity != null)
                    {
                        var resource = principalSecurity._resources;
                        var operation = principalSecurity._action;

                        isVisible = ClaimsAuthorization.CheckAccess(operation, resource);
                    }
                }
            }

            if (isVisible)
            {
                var htmlHelperFull = sourceMetadata["HtmlHelper"].ToString();
                var htmlHelper = htmlHelperFull.SubstringAfterLast('.').ToLower().Replace("extensions", "");

                if (mvcNode != null && mvcNode["visibility"] != null)
                {
                    string[] visibilityAttrs = mvcNode["visibility"].Split(',');
                    foreach (var attrib in visibilityAttrs)
                    {
                        var clean = attrib.TrimEnd().TrimStart().ToLower();
                        if (clean == htmlHelper)
                        {
                            return false;
                        }
                    }

                }
            }

            return isVisible;
        }
    }
}