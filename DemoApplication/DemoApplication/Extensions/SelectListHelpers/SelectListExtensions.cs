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
namespace DemoApplication.Extensions.SelectListHelpers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    #endregion

    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> SetSelected(this IEnumerable<SelectListItem> selectList, object selectedValue)
        {
            selectList = selectList ?? new List<SelectListItem>();
            if (selectedValue == null)
                return selectList;
            var vlaue = selectedValue.ToString();
            return selectList
                .Select(m => new SelectListItem
                                 {
                                     Selected = string.Equals(vlaue, (string) m.Value),
                                     Text = m.Text,
                                     Value = m.Value
                                 });
        }


        public static IEnumerable<SelectListItem> GetAutomatedList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                      Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return ((IEnumerable<SelectListItem>)htmlHelper.ViewData["DDKey_" + metadata.PropertyName]);
        }
    }
}