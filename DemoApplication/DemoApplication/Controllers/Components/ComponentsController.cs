using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApplication.Controllers.Components
{
    using Models.Components;

    public class ComponentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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
