namespace DemoApplication.Dropdowns.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> SetSelected(this IEnumerable<SelectListItem> selectList, object selectedValue)
        {
            selectList = selectList ?? new List<SelectListItem>();
            if (selectedValue == null)
                return selectList;
            var value = selectedValue.ToString();
            return selectList
                .Select(m => new SelectListItem
                                 {
                                     Selected = string.Equals(value, (string)m.Value),
                                     Text = m.Text,
                                     Value = m.Value
                                 });
        }

        public static IEnumerable<SelectListItem> GetAutomatedList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return GetAutomatedList(htmlHelper, ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData));
        }

        public static IEnumerable<SelectListItem> GetAutomatedList(this HtmlHelper helper, ModelMetadata metadata)
        {
            return helper.GetAutomatedList("DDKey_" + metadata.PropertyName);
        }

        public static IEnumerable<SelectListItem> GetAutomatedList(this HtmlHelper helper, string name)
        {
            return ((IEnumerable<SelectListItem>)helper.ViewData[name]);
        }
    }
}