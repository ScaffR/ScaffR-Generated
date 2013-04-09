#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Marko Ilievski
// Created	: 04-05-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-05-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Filters
{
    #region

    using System.Web;
    using System.Web.Management;
    using System.Web.Mvc;

    #endregion

    internal sealed class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.ExceptionHandled) // if unhandled, will be logged anyhow
                return;

            context.ExceptionHandled = true;

            if (context.HttpContext.Request.IsAjaxRequest())
            {
                context.Result = new HttpStatusCodeResult(550, "Sorry error occured.");
                return;
            }

            HttpException httpException = context.Exception as HttpException;

            if (httpException == null)
            {
                context.Result = new ViewResult { ViewName = "ServerError" };
                return;
            }

            switch (httpException.GetHttpCode())
            {
                case 404:
                    // Page not found.
                    context.Result = new ViewResult { ViewName = "NotFound" };
                    break;
                case 500:
                    // Server error.
                    context.Result = new ViewResult { ViewName = "ServerError" };
                    break;
                // Here you can handle Views to other error codes.
                // I choose a General error template  
                default:
                    context.Result = new ViewResult { ViewName = "ServerError" };
                    break;
            }

        }
    }
}