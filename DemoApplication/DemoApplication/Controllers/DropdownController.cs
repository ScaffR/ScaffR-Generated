namespace DemoApplication.Controllers
{
    using System.Web.Mvc;
    using System.Reflection;
    using Dropdowns;

    public class DropdownController : Controller
    {
        public JsonResult GetDropdownFor(string method, string parameter)
        {
            var staticType = typeof(Dropdowns);
            MethodInfo methodInfo = staticType.GetMethod(method, BindingFlags.Static | BindingFlags.Public);

            object[] param = null;
            if (parameter != null)
                param = parameter.Split('|');

            var listObj = methodInfo.Invoke(null, param);
            return Json(listObj, JsonRequestBehavior.AllowGet);
        }

    }
}
