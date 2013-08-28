using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Models.Beaches;
using Omu.ValueInjecter;

namespace ParadiseBookers.Controllers.Beaches
{
    public class BeachesController : Controller
    {
        private readonly IBeachService _service;

        public BeachesController(IBeachService service)
        {
            _service = service;
        }

        //
        // GET: /Beaches/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manager()
        {
            var model = _service.GetAll().ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View(new BeachViewModel());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BeachViewModel());
        }

        [HttpPost]
        public ActionResult Create(BeachViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beach = new Beach();
                beach.InjectFrom<UnflatLoopValueInjection>(model);
                _service.CreateBeach(beach);
                return RedirectToAction("Manager");
            }

            return View(model);
        }

        public ActionResult Photos(int id)
        {
            return View();
        }

    }
}
