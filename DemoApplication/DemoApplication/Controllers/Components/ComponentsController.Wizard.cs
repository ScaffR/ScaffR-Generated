#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-06-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Models.Components;

    #endregion

    public partial class ComponentsController
    {
        /// <summary>
        /// Demonstration of the wizard control.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Wizard()
        {
            return View(new SampleWizardModel());
        }

        /// <summary>
        /// Demonstration of the wizard control.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Wizard(SampleWizardModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Model was saved successfully";
                return RedirectToAction("Wizard");
            }
            return View(model);
        }

    }
}
