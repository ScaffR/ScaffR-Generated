#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.HtmlHelpers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using DemoApplication.Core.Interfaces.Site;

    #endregion

    public static partial class HtmlExtensions
    {
        public static MvcHtmlString ClientIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(
                htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)));
        }

        public static string GetPageHeadingText(this HtmlHelper helper, string title = null)
        {
            var rules = new List<Func<string>>
                {
                    () => title,
                    () => helper.ViewBag.Title,
                    () =>
                        {
                          if (SiteMap.CurrentNode != null)
                          {
                              return SiteMap.CurrentNode.Title;
                          }
                          return null;
                        }
                };

            foreach (var rule in rules)
            {
                title = rule();
                if (!string.IsNullOrEmpty(title))
                    break;
            }

            return title;
        }

        public static string GetWebsiteTitle(this HtmlHelper helper)
        {
            var settings = DependencyResolver.Current.GetService<ISiteSettings>();
            return settings.WebsiteName;
        }

        public static string GetPageTitle(this HtmlHelper helper)
        {            
            return GetWebsiteTitle(helper) + " - " + GetPageHeadingText(helper);
        }
    }
}