using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Extensions
{
    using System.Web.Mvc;

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