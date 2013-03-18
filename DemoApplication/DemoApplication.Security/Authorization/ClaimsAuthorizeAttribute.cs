#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Authorization
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        public string _action;
        public string[] _resources;

        private const string _label = "Thinktecture.IdentityModel.Authorization.Mvc.ClaimsAuthorizeAttribute";

        public ClaimsAuthorizeAttribute()
        { }

        public ClaimsAuthorizeAttribute(string action, params string[] resources)
        {
            _action = action;
            _resources = resources;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Items[_label] = filterContext;
            base.OnAuthorization(filterContext); 
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (!string.IsNullOrWhiteSpace(_action))
            {
                return ClaimsAuthorization.CheckAccess(_action, _resources);
            }
            else
            {
                var filterContext = httpContext.Items[_label] as AuthorizationContext;
                return CheckAccess(filterContext);
            }
        }

        protected virtual bool CheckAccess(AuthorizationContext filterContext)
        {
            var action = filterContext.RouteData.Values["action"] as string;
            var controller = filterContext.RouteData.Values["controller"] as string;

            return ClaimsAuthorization.CheckAccess(action, controller);
        }
    }
}
