#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ParadiseBookers.Extensions.ActionDescriptorHElpers
{
    #region

    

    #endregion

    public static class ActionDescriptorExtensions
    {
        public static void SafeRedirect(this ActionExecutingContext context, string actionName, string controllerName)
        {
            var aName = context.ActionDescriptor.ActionName;
            var cName = context.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (!(controllerName.Equals(cName, StringComparison.InvariantCultureIgnoreCase) && actionName.Equals(aName, StringComparison.InvariantCultureIgnoreCase)))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                        {
                            { "controller", controllerName },
                            { "action", actionName }                                                 
                        });
            }
        }
    }
}