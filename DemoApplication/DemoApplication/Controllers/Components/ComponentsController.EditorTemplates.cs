#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Extensions.TempDataHelpers;
    using Models.Components;

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
        [HttpPost]
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
