using System.Web.Mvc;

namespace DemoApplication.Controllers.Logging
{
    public class LoggingController : Controller
    {
        public ActionResult Manage()
        {
            return View("Results");
        }

        public ActionResult Success()
        {
            return View("Results");
        }

        public ActionResult Error()
        {
            return View("Results");
        }

        public ActionResult Fatal()
        {
            return View("Results");
        }

        public ActionResult Warning()
        {
            return View("Results");
        }
    }
}
