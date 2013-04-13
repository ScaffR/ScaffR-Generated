#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Filters;
    using Models.Components;

    #endregion

    public partial class ComponentsController
    {

        //private readonly Common.Logging.ILog _logger = Common.Logging.LogManager.GetCurrentClassLogger();
        //
        // GET: /Logging/

        [Log, AllowAnonymous]
        public ActionResult Exceptions()
        {            
            return View();
        }

        [HttpPost,AllowAnonymous]
        public ActionResult Throw500()
        {            
            throw new NotImplementedException("This should give a 500 error");
        }
        
    }
}
