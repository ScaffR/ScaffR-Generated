#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Marko Ilievski
// Created	: 03-28-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Filters
{
    #region

    using System.Web.Mvc;
    using Security.Authorization;
    using Security.Extensions;

    #endregion

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;

            // If the action or controller has AllowAnonymous or OnlyAnonymous Attributes should let them pass
            if (actionDescriptor.HasAttribute<AllowAnonymousAttribute>()) return;

            if (actionDescriptor.HasAttribute<OnlyAnonymousAttribute>() &&
                !filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
                return;

            base.OnAuthorization(filterContext);
        }
    }
}