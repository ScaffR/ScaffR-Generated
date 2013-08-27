#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Marko Ilievski
// Created	: 04-12-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;
using ParadiseBookers.Extensions.ErrorHandlingHelpers;

namespace ParadiseBookers.Controllers
{
    #region

    

    #endregion

    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Renders a not found page.
        /// </summary>
        /// <returns>Empty result</returns>
        protected ActionResult InvokeNotFound()
        {
            (new NotFoundController()).Execute(Request.RequestContext);

            // We need this because usually actions require something returned
            return new EmptyResult();
        }
    }
}
