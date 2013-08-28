using System.Linq;
using System.Web.Mvc;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Models.Properties;
using Omu.ValueInjecter;
namespace ParadiseBookers.Controllers.Properties
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService PropertyService;

        public PropertiesController(IPropertyService service)
        {
            PropertyService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Properties/        
        public ActionResult Manager(int page = 1, int pageSize = 10)
        {
            var model = PropertyService.GetAll().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PropertyViewModel());
        }

        [HttpPost]
        public ActionResult Create(PropertyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Property();

                model.InjectFrom<UnflatLoopValueInjection>(viewModel);

                PropertyService.CreateProperty(model);

                return RedirectToAction("Manager");
            }
           

            return View(viewModel);
        }

        public ActionResult Photos(int id)
        {
            var property = PropertyService.GetByID(id);
            var model = new PropertyViewModel().InjectFrom<UnflatLoopValueInjection>(property);
            return View(model);
        }

        public ActionResult Websites(int id)
        {
            var property = PropertyService.GetByID(id);
            var model = new PropertyViewModel().InjectFrom<UnflatLoopValueInjection>(property);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var property = PropertyService.GetByID(id);
            var model = new PropertyViewModel().InjectFrom<UnflatLoopValueInjection>(property);
            return View(model);
        }

        [HttpGet]
        public ActionResult Rates(int id)
        {
            var property = PropertyService.GetByID(id);
            var model = new PropertyViewModel().InjectFrom<UnflatLoopValueInjection>(property);
            return View(model);
        }

        public ActionResult Promote(int id)
        {
            var property = PropertyService.GetByID(id);
            var model = new PropertyViewModel().InjectFrom<UnflatLoopValueInjection>(property);
            return View(model);
        }
    }
}
