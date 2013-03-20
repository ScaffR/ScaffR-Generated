#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Filters
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ShowPageHeadingText : ActionFilterAttribute
    {
        private readonly bool _show;

        public ShowPageHeadingText(bool show = true)
        {
            _show = show;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.ShowMainMenu = _show;

            base.OnActionExecuted(filterContext);
        }
    }
}