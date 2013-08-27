#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Marko Ilievski
// Created	: 04-12-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion

using System;
using System.Net;
using System.Web.Mvc;
using ParadiseBookers.Extensions.ErrorHandlingHelpers;

namespace ParadiseBookers.Filters
{
    #region

    

    #endregion

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomHandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public virtual void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (filterContext.IsChildAction)
            {
                return;
            }

            // If custom errors are disabled, we need to let the normal ASP.NET exception handler
            // execute so that the user can see useful debugging information.
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ErrorResult
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
            };

            filterContext.ExceptionHandled = true;
        }
    }
}