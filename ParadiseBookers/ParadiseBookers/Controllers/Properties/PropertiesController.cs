using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Properties
{
    public class PropertiesController : Controller
    {
        //
        // GET: /Properties/

        public ActionResult Manager(int page = 1, int pageSize = 10)
        {
            //var model = UserService.GetAll("default").ToList();
            //return View(model);
            return View();
        }

    }
}
