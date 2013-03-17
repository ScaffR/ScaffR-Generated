#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.SitemapHelpers
{
    #region

    using System.Web.Mvc;

    #endregion

    public static partial class BootstrapHelpers
    {
        public static MvcHtmlString AddClass(this HtmlHelper helper, string className, bool active)
        {
            if (active)
            {
                return new MvcHtmlString(" " + className + " ");
            }
            return new MvcHtmlString("");
        }

        public static MvcHtmlString ActiveWhen(this HtmlHelper helper, string actionName, string controllerName, string extraClasses = "")
        {
            var currentActionName = helper.ViewContext.RouteData.Values["action"].ToString();
            var currentControllerName = helper.ViewContext.RouteData.Values["controller"].ToString();

            if ((controllerName.ToLower() == currentControllerName.ToLower()) &&
                (actionName.ToLower() == currentActionName.ToLower()))
                return new MvcHtmlString("class = 'active " + extraClasses + "'");

            return new MvcHtmlString("");
        }
    }
}