#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security (moved from DemoApplication)
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Security.Authorization
{
    #region

    using System.Web.Mvc;
    using System.Web.Security;

    #endregion

    public class OnlyAnonymousAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.DefaultUrl);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
