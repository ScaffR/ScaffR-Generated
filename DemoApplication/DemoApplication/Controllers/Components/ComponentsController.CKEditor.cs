namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Models.Components;

    #endregion

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
