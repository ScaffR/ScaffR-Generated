namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Models.Components;

    #endregion

    public partial  class ComponentsController
    {
        public ActionResult DropDown()
        {
            return View(new SampleDropdownModel());
        }
    }
}