#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Web.Mvc;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Models.Admin;
using ParadiseBookers.Models.Common;

namespace ParadiseBookers.Controllers.Home
{
    #region

    

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
            // GET TOTALS
            int totalall = _service.GetCountByDateCreatedRange(DateTime.MinValue, DateTime.Now);
            int totaltoday = _service.GetCountByDateCreatedRange(DateTime.Now, DateTime.Now);
            int totalweek = _service.GetCountByDateCreatedRange(DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek), DateTime.Now);
            int totalmonth = _service.GetCountByDateCreatedRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now);

            // GET MODEL
            var model = new AdminHomeModel { UserSignupModel = new BarGraphModel() { MaxValue = totalall, Title = "User Signups" } };

            // TOTAL OF SIGNUPS TODAY
            model.UserSignupModel.Sections.Add(new BarGraphSection()
            {
                Title = "Today",
                Class = "progress progress-warning",
                Number = totaltoday,
                Percentage = Convert.ToInt32((Convert.ToDecimal(totaltoday) / Math.Max(model.UserSignupModel.MaxValue, 1)) * 100)
            });

            // TOTAL OF SIGNUPS THIS WEEK            
            model.UserSignupModel.Sections.Add(new BarGraphSection()
            {
                Title = "This Week",
                Class = "progress progress-danger",
                Number = totalweek,
                Percentage = Convert.ToInt32((Convert.ToDecimal(totalweek) / Math.Max(model.UserSignupModel.MaxValue, 1)) * 100)
            });

            // TOTAL OF SIGNUPS THIS MONTH            
            model.UserSignupModel.Sections.Add(new BarGraphSection()
            {
                Title = "This Month",
                Class = "progress",
                Number = totalmonth,
                Percentage = Convert.ToInt32((Convert.ToDecimal(totalmonth) / Math.Max(model.UserSignupModel.MaxValue, 1)) * 100)
            });

            // TOTAL OF SIGNUPS            
            model.UserSignupModel.Sections.Add(new BarGraphSection()
            {
                Title = "Total Signups",
                Class = "progress progress-success",
                Number = totalall,
                Percentage = Convert.ToInt32((Convert.ToDecimal(totalall) / Math.Max(model.UserSignupModel.MaxValue, 1)) * 100)
            });

            return View(model);
        }
    }
}