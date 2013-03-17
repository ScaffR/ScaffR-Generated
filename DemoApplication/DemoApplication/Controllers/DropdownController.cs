namespace DemoApplication.Controllers
{
    #region

    using System.Reflection;
    using System.Web.Mvc;
    using Dropdowns;

    #endregion

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
