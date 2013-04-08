#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using DemoApplication.Infrastructure.Logging;

namespace DemoApplication.Application
{
    #region

    using System;

    #endregion

    public partial class MvcApplication
	{
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            new WebErrorEventEx(ex, this).Raise();                         

            //var httpContext = ((MvcApplication)sender).Context;
            //var currentController = " ";
            //var currentAction = " ";
            //var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            //if (currentRouteData != null)
            //{
            //    if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
            //    {
            //        currentController = currentRouteData.Values["controller"].ToString();
            //    }

            //    if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
            //    {
            //        currentAction = currentRouteData.Values["action"].ToString();
            //    }
            //}

            //var ex = Server.GetLastError();
            //var controller = new ErrorController();
            //var routeData = new RouteData();
            //var action = "Index";

            //if (ex is HttpException)
            //{
            //    var httpEx = ex as HttpException;

            //    switch (httpEx.GetHttpCode())
            //    {
            //        case 404:
            //            action = "NotFound";
            //            break;

            //        case 401:
            //            action = "AccessDenied";
            //            break;
            //    }
            //}
            //if (ex is SecurityException)
            //{
            //    action = "AccessDenied";
            //}

            //httpContext.ClearError();
            //httpContext.Response.Clear();
            //httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            //httpContext.Response.TrySkipIisCustomErrors = true;

            //routeData.Values["controller"] = "Error";
            //routeData.Values["action"] = action;

            //controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            //((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }
	}
}