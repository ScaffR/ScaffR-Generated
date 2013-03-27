#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Error
{
    #region

    using System.Web.Mvc;
    using Filters;

    #endregion

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
