#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Home
{
    #region

    using System.Web.Mvc;
    using Core.Interfaces.Service;
    using Models.Admin;
    using Models.Common;

    #endregion

    public partial class HomeController : Controller
    {
        private readonly IUserAccountService _service;

        public HomeController(IUserAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// Landing page for the administrative portion of the website
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize(Roles = "Admin,Super Admin")]
        public ActionResult Manage()
        {
           

            var model = new AdminHomeModel
                {
                    UserSignupModel = new BarGraphModel(){MaxValue = 100, Title = "Something awesome"}
                };
            model.UserSignupModel.Sections.Add(new BarGraphSection()
                {
                    Title = "ASdf",
                    Color = "red",
                    Number = 1
                });

            return View(model);
        }
    }
}