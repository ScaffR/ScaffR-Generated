using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Restaurants
{
    public class RestaurantsController : Controller
    {
        //
        // GET: /Restaurants/

        public ActionResult Index()
        {
            return View();
        }

    }
}
