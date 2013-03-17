namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Models.Components;

    #endregion

    public partial class ComponentsController : Controller
    {

        public ActionResult Wizard()
        {
            return View(new SampleWizardModel());
        }

        [HttpPost]
        public ActionResult Wizard(SampleWizardModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Model was saved successfully";
            }
            return View(model);
        }

    }
}
