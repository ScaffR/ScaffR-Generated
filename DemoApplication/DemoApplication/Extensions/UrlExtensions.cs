namespace DemoApplication.Extensions
{
    using System.Web.Mvc;

    public static partial class UrlExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName, object routeValues = null)
        {
            if (url.RequestContext.HttpContext.Request.Url != null)
            {
                string scheme = url.RequestContext.HttpContext.Request.Url.Scheme;
                return url.Action(actionName, controllerName, routeValues, scheme);
            }
            return null;
        }
       
    }
}