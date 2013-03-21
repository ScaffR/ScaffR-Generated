using System.Collections.Generic;
using System.Web.Mvc;
using DemoApplication.Models.Components;
using DemoApplication.Filters;

namespace DemoApplication.Controllers.Components
{

    public partial class ComponentsController
    {

        private readonly Common.Logging.ILog _logger = Common.Logging.LogManager.GetCurrentClassLogger();
        //
        // GET: /Logging/

        [Log, AllowAnonymous]
        public ActionResult Logging()
        {
            var model = new List<SampleLoggingModel>
            {
                new SampleLoggingModel
                {
                    Status = EventStatus.Info
                },
                new SampleLoggingModel
                {
                    Status = EventStatus.Fatal
                },
                new SampleLoggingModel
                {
                    Status = EventStatus.Debug
                },
                new SampleLoggingModel
                {
                    Status = EventStatus.Warning
                },
                new SampleLoggingModel
                {
                    Status = EventStatus.Error
                },
                new SampleLoggingModel
                {
                    Status = EventStatus.Success
                }

            };
    
            return View(model);
        }

        [HttpPost,AllowAnonymous]
        public ActionResult Logging(List<SampleLoggingModel> models)
        {
            
            foreach (var log in models)
            {
                if (string.IsNullOrEmpty(log.Event))
                    continue;

                switch (log.Status)
                {
                    case EventStatus.Error :
                        _logger.ErrorFormat("Logging '{0}'", log.Event);
                        break;
                    case EventStatus.Warning:
                        _logger.WarnFormat("Logging '{0}'", log.Event);
                        break;
                    case EventStatus.Info:
                        _logger.InfoFormat("Logging '{0}'", log.Event);
                        break;
                    case EventStatus.Success:
                        _logger.InfoFormat("Logging '{0}'", log.Event);
                        break;
                    case EventStatus.Debug:
                        _logger.DebugFormat("Logging '{0}'", log.Event);
                        break;
                    case EventStatus.Fatal:
                        _logger.FatalFormat("Logging '{0}'", log.Event);
                        break;

                } 
            }
             
            return RedirectToAction("Logging", "Components");
        }
        
    }
}
