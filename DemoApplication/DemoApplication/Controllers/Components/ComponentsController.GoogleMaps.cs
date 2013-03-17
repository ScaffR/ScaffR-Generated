namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Core.Common.Geography;
    using Models.Common;

    #endregion

    public partial class ComponentsController
    {

        public ActionResult GoogleMaps()
        {
            var model = new AddressModel
            {
                Address = "301 15th Street, Hood River",
                Location = GeographyHelpers.CreatePoint(45.7120903, -121.5272902)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GoogleMaps(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Location was successfuly submitted";
            }
            return View(model);
        }

    }
}
