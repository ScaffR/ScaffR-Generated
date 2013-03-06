using System.Web.Mvc;

namespace DemoApplication.Controllers.Components
{
    using Models.Components;

    public partial class ComponentsController
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
