namespace DemoApplication.Controllers.Home
{
    #region

    using System.Web.Mvc;
    using Filters;
    using Security.Authorization;

    #endregion

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