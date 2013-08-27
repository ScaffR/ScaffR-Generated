#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Logging
{
    #region

    

    #endregion

    public class LoggingController : Controller
    {
        public ActionResult Manage()
        {
            return View("Results");
        }

        public ActionResult Success()
        {
            return View("Results");
        }

        public ActionResult Error()
        {
            return View("Results");
        }

        public ActionResult Fatal()
        {
            return View("Results");
        }

        public ActionResult Warning()
        {
            return View("Results");
        }
    }
}
