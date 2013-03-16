using System.Web.Mvc;

namespace DemoApplication.Controllers.Components
{
    using Models.Components;

    public partial class ComponentsController : Controller
    {
        public ActionResult EditorTemplates()
        {
            var model = new SampleEditorTemplatesModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditorTemplates(SampleEditorTemplatesModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "This was a success";
                return RedirectToAction("EditorTemplates");
            }
            return View(model);
        }
      
    }
}
