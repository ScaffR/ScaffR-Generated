﻿#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.HtmlHelpers
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Core.Extensions;
    using StringHelpers;
    using TempDataHelpers;

    #endregion

    public static partial class HtmlExtensions
    {
        public static MvcHtmlString GetAlerts(this HtmlHelper helper, AlertType alertType, AlertLocation alertLocation)
        {            
            var alertData = helper.ViewContext.TempData.InitializeAlertData();

            List<string> messages = alertData[alertLocation][alertType];
            if (messages.Count > 0)
            {
                var outerBuilder = new TagBuilder("div");
                outerBuilder.AddCssClass("container-fluid");
                foreach (var message in messages)
                {
                    var builder = new TagBuilder("div");
                    builder.AddCssClass("alert");
                    builder.AddCssClass("in");
                    builder.AddCssClass("fade");
                    builder.AddCssClass(alertType.GetDescription());

                    builder.SetInnerText(message);

                    var closeButton = new TagBuilder("a");
                    closeButton.AddCssClass("close");
                    closeButton.MergeAttribute("data-dismiss", "alert");
                    closeButton.MergeAttribute("href", "#");
                    closeButton.InnerHtml += "&times;";

                    builder.InnerHtml += closeButton.ToString(TagRenderMode.Normal);

                    outerBuilder.InnerHtml += builder.ToString(TagRenderMode.Normal);
                }
                return outerBuilder.ToString(TagRenderMode.Normal).ToMvcHtmlString();
            }

            return string.Empty.ToMvcHtmlString();
        }        
    }
}