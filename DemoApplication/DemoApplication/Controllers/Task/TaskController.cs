namespace DemoApplication.Controllers.Task
{
    using System.Web.Mvc;
    using Core.Common.Security;

    public class TaskController : Controller
    {
        [ClaimsAuthorize("View", "TaskManager")]
        public ActionResult Manager()
        {
            return View();
        }
    }
}