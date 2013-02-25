namespace DemoApplication.Controllers
{
    using System.Web.Mvc;

    public class DropdownController : Controller
    {
        public JsonResult GetDropdownFor(string method, string parameter)
        {
            return Json(Dropdowns.Dropdowns.UnitedStates(), JsonRequestBehavior.AllowGet);
        }

    }
}
