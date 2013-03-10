using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Controllers.Components
{
    using System.Web.Mvc;
    using Models.Components;

    public partial  class ComponentsController
    {
        public ActionResult DropDown()
        {
            return View(new SampleDropdownModel());
        }
    }
}