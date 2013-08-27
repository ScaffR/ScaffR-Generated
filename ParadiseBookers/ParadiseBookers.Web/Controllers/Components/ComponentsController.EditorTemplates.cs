#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;
using ParadiseBookers.Extensions.TempDataHelpers;
using ParadiseBookers.Models.Components;

namespace ParadiseBookers.Controllers.Components
{
    #region

    

    #endregion

    /// <summary>
    /// Class ComponentsController
    /// </summary>
    public partial class ComponentsController : Controller
    {
        /// <summary>
        /// Demonstration of the EditorTemplates
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult EditorTemplates()
        {
            var model = new SampleEditorTemplatesModel();

            return View(model);
        }

        /// <summary>
        /// Demonstration of the EditorTemplates
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, AllowAnonymous]
        public ActionResult EditorTemplates(SampleEditorTemplatesModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.AddSuccessMessage("This was a success");
                return RedirectToAction("EditorTemplates");
            }
            return View(model);
        }
      
    }
}
