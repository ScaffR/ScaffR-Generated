#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Dropdowns
{
    #region

    using System.Reflection;
    using System.Web.Mvc;
    using DemoApplication.Dropdowns.Dropdowns;

    #endregion

    public class DropdownController : Controller
    {
        /// <summary>
        /// Gets the dropdown for.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>JsonResult.</returns>
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
