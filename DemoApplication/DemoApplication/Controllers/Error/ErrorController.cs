using System.Web.Mvc;
using DemoApplication.Filters;

namespace DemoApplication.Controllers.Error
{
  [AllowAnonymous]
  [ShowMainMenu(false), ShowBreadcrumb(false), ShowAlerts(false), ShowPageHeadingText(false)]
  public class ErrorController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult NotFound()
    {
      return View();
    }

    public ActionResult AccessDenied()
    {
      return View();
    }
  }
}
