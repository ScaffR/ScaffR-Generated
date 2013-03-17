namespace DemoApplication.Filters
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ShowAlerts : ActionFilterAttribute
    {
        private readonly bool _show;

        public ShowAlerts(bool show = true)
        {
            _show = show;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.ShowAlerts = _show;

            base.OnActionExecuted(filterContext);
        }
    }
}