namespace DemoApplication.Filters
{
    using System.Web.Mvc;

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