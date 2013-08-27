#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;

namespace ParadiseBookers.Filters
{
    #region

    

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
            filterContext.Controller.ViewBag.ShowPageHeadingText = _show;

            base.OnActionExecuted(filterContext);
        }
    }
}