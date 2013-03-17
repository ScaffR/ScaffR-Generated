namespace DemoApplication.Filters
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ShowBreadcrumb : ActionFilterAttribute
    {
        private readonly bool _show;

        public ShowBreadcrumb(bool show = true)
        {
            _show = show;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.ShowBreadcrumb = _show;

            base.OnActionExecuted(filterContext);
        }
    }
}