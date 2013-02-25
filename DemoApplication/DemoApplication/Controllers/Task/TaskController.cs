namespace DemoApplication.Controllers.Task
{
    using System.Web.Mvc;
    using IdentityModel.Authorization.MVC;

    public class TaskController : Controller
    {
        [ClaimsAuthorize("View", "TaskManager")]
        public ActionResult Manager()
        {
            return View();
        }
    }
}