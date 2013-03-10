namespace DemoApplication.Controllers.Home
{
    using System.Web.Mvc;
    using Core.Common.Security;
    using Filters;

    public partial class HomeController : Controller
    {
       [AllowAnonymous, ShowMainMenu(false)] 
       public ActionResult Index()
       {
           return View();
       }

        [ClaimsAuthorize("View", "ManageUsers")]
        public ActionResult Manage()
        {
            return Content("No Content");
        }
    }
}