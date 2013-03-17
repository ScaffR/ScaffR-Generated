#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.TempDataHelpers
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;

    #endregion

    public static class TempDataExtensions
    {
        public static void Success(this TempDataDictionary dictionary, ViewContext context, string message,
            AlertLocation location = AlertLocation.Top)
        {
            var viewbag = context.Controller.ViewBag;

            var alertData = viewbag.AlertData as Dictionary<AlertLocation, Dictionary<AlertType, string>>;
            if (alertData == null)
            {
                viewbag.AlertData = alertData = new Dictionary<AlertLocation, Dictionary<AlertType, string>>();
            }

            if (alertData[location] == null)
            {
                alertData[location] = new Dictionary<AlertType, string>();
            }

            alertData[location].Add(AlertType.Success, message);
        }
    }
}