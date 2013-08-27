#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Reflection;
using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Dropdowns
{
    #region

    

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
            var staticType = typeof(ParadiseBookers.Dropdowns.Dropdowns.Dropdowns);
            MethodInfo methodInfo = staticType.GetMethod(method, BindingFlags.Static | BindingFlags.Public);

            object[] param = null;
            if (parameter != null)
                param = parameter.Split('|');

            var listObj = methodInfo.Invoke(null, param);
            return Json(listObj, JsonRequestBehavior.AllowGet);
        }

    }
}
