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
                    YoutubeHtml5 = new VideoModel { Source = "http://www.youtube.com/embed/pAwR6w2TgxY" },
                    YoutubeFlash = new VideoModel { Source = "http://www.youtube.com/v/qs1bG6BIYlo" },
                    Mp4Html5 = new VideoModel { Source = "http://www.w3schools.com/html/mov_bbb.mp4" }
                };

            return View(model);
        }
      
    }
}
