#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Andrew Davey (https://github.com/andrewdavey/notfoundmvc)
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Extensions.ErrorHandlingHelpers
{
    #region

    using System.Web;
    using System.Web.Mvc;

    #endregion

    class ActionInvokerWrapper : IActionInvoker
    {
        readonly IActionInvoker actionInvoker;

        public ActionInvokerWrapper(IActionInvoker actionInvoker)
        {
            this.actionInvoker = actionInvoker;
        }

        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (InvokeActionWith404Catch(controllerContext, actionName))
                return true;

            // No action method was found, or it was, but threw a 404 HttpException.
            (new NotFoundController()).Execute(controllerContext.RequestContext);

            return true;
        }

        bool InvokeActionWith404Catch(ControllerContext controllerContext, string actionName)
        {
            try
            {
                return actionInvoker.InvokeAction(controllerContext, actionName);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpCode() == 404)
                {
                    // TODO: Log the exception

                    return false;
                }
                throw;
            }
        }
    }
}