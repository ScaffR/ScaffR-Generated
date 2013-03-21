#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-06-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Extensions.TempDataHelpers;
    using Models.Components;

    #endregion

    public partial class ComponentsController
    {
        /// <summary>
        /// Demonstration of the wizard control.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult Wizard()
        {
            return View(new SampleWizardModel());
        }

        /// <summary>
        /// Demonstration of the wizard control.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, AllowAnonymous]
        public ActionResult Wizard(SampleWizardModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.AddSuccessMessage("Model was saved successfully");
                TempData.AddErrorMessage("Model wasn't saved successfully");
                TempData.AddInfoMessage("This is just information");
                return RedirectToAction("Wizard");
            }
            return View(model);
        }

    }
}
