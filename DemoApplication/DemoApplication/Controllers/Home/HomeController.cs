namespace DemoApplication.Controllers.Home
{
    using System.Web.Mvc;
    using IdentityModel.Authorization.MVC;

    public partial class HomeController : Controller
    {
       [AllowAnonymous] 
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