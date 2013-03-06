using System.Web.Mvc;

namespace DemoApplication.Controllers.Components
{
    using Models.Components;

    public partial class ComponentsController : Controller
    {

        public ActionResult Video()
        {
            var model = new SampleVideoModel
                {
                    YoutubeHtml5 = new VideoModel { Source = "http://www.youtube.com/embed/7cXn1sCKSmI" },
                    YoutubeFlash = new VideoModel { Source = "http://www.youtube.com/v/7cXn1sCKSmI" },
                    Mp4Html5 = new VideoModel { Source = "http://www.w3schools.com/html/mov_bbb.mp4" }
                };

            return View(model);
        }
      
    }
}
