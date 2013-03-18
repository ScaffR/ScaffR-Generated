#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.HtmlHelpers
{
    #region

    using System.Web.Mvc;

    #endregion

    public static partial class BootstrapHelpers
    {
        /// <summary>
        /// Actives the when.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="extraClasses">The extra classes.</param>
        /// <returns>MvcHtmlString.</returns>
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