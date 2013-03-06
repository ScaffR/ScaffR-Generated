using System.Web.Mvc;

namespace DemoApplication.Controllers.Components
{
    using Models.Components;

    public partial class ComponentsController
    {

        public ActionResult CKEditor()
        {
            return View(new CKEditorModel());
        }

        [HttpPost]
        public ActionResult CKEditor(CKEditorModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Model was saved successfully";
            }
            return View(model);
        }

    }
}
