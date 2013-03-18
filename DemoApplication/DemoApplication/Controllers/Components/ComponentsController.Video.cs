#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-07-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Models.Components;

    #endregion

    public partial class ComponentsController
    {
        /// <summary>
        /// Demonstration of the Video Player DisplayTemplates.
        /// </summary>
        /// <returns>ActionResult.</returns>
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
