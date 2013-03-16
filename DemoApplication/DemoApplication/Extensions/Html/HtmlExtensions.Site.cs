namespace DemoApplication.Extensions.Html
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web;
    using System;
    using System.Web.Mvc;
    using Core.Common.Site;

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

        public static string GetPageTitle(this HtmlHelper helper)
        {
            return Site.Instance.WebsiteName + " - " + GetPageHeadingText(helper);
        }
    }
}