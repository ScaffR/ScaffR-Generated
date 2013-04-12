#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Marko Ilievski
// Created	: 04-12-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Extensions.ErrorHandlingHelpers
{
    #region

    using System.Net;
    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    public class NotFoundController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            (new ErrorResult { StatusCode = HttpStatusCode.NotFound }).ExecuteResult(
                new ControllerContext(requestContext, new FakeController())
            );
        }

        // ControllerContext requires an object that derives from ControllerBase.
        // NotFoundController does not do this.
        // So the easiest workaround is this FakeController.
        class FakeController : Controller { }
    }
}