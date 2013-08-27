#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-07-2013
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
    public partial class ComponentsController
    {
        /// <summary>
        /// Demonstration of the CKEditor template.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CKEditor()
        {
            return View(new SampleEditorModel());
        }

        /// <summary>
        /// Demonstration of the CKEditor template.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult CKEditor(SampleEditorModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.AddSuccessMessage("Model was saved successfully");
            }
            return View(model);
        }

    }
}
