namespace DemoApplication.Controllers.Home
{
    using System.Web.Mvc;
    using Filters;
    using Security;
    using Security.Authorization;

    public partial class HomeController : Controller
    {
       [AllowAnonymous, ShowMainMenu(false)] 
       public ActionResult Index()
       {
           if (Request.IsAuthenticated)
           {
               return View("Dashboard");
           }
           return View();
       }

        [ClaimsAuthorize("View", "ManageUsers")]
        public ActionResult Manage()
        {
            return View();
        }
    }
}