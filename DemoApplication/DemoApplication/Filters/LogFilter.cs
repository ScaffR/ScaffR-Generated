using System;
using System.Globalization;
using System.Web.Mvc;
using Common.Logging;

namespace DemoApplication.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class LogAttribute : ActionFilterAttribute
    {
        private readonly ILog _logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.InfoFormat(CultureInfo.InvariantCulture, 
                "Executing action {0}.{1}", 
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _logger.InfoFormat(CultureInfo.InvariantCulture,
                "Executed action {0}.{1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName);
        }
    }
}