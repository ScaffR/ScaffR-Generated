#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-05-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ParadiseBookers.Filters
{
    #region

    

    #endregion

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public class MultiResponseFormatAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			
			var viewResult = filterContext.Result as ViewResult;
			if (viewResult == null)
				return;

            var request = filterContext.HttpContext.Request;
            var modelState = filterContext.Controller.ViewData.ModelState;
            var errors = new Dictionary<string, IList<string>>();

            foreach (var key in modelState.Keys)
            {
                if (modelState[key].Errors.Count > 0)
                {
                    errors.Add(key, modelState[key].Errors.Select(e => e.ErrorMessage).ToList());
                }
            }

			if (request.IsAjaxRequest())
			{
                if ( request["format"].Equals("json") )
                {
                    // Replace result with JsonResult
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            success = errors.Count == 0,
                            model = viewResult.Model,
                            errors = errors
                        }
                    };
                }
                else { 
				    // Replace result with PartialViewResult
				    filterContext.Result = new PartialViewResult
				    {
					    TempData = viewResult.TempData,
					    ViewData = viewResult.ViewData,
					    ViewName = viewResult.ViewName,
				    };
                }
			}
		}
	}
}