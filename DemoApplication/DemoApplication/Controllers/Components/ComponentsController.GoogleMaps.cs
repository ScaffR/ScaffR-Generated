using System.Web.Mvc;

namespace DemoApplication.Controllers.Components
{
    using Models.Components;

    public partial class ComponentsController
    {

        public ActionResult GoogleMaps()
        {
            return View(new SampleAddressModel());            
        }

        [HttpPost]
        public ActionResult GoogleMaps(SampleAddressModel model)
        {
            return View(model);
        }

    }
}
