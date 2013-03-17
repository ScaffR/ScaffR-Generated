namespace DemoApplication.Filters
{
    #region

    using System.Web.Mvc;
    using System.Web.Security;

    #endregion

    public class OnlyAnonymous : ActionFilterAttribute
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