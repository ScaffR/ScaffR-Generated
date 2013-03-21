#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns.Controls
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using Extensions;

    #endregion

    public static class DropDownExtensions
    {
        public static MvcHtmlString DropDownFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, object model, IDictionary<string, object> attrs = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            return DropDownHelper(helper, metadata, model, attrs);
        }

        private static void NormalizeAttributes(ModelMetadata metadata, ref IDictionary<string, object> attributes )
        {
            if (metadata.AdditionalValues.ContainsKey("parentName"))
                attributes.Add("data-cascading-parent", metadata.AdditionalValues["parentName"]);

            if (metadata.AdditionalValues.ContainsKey("heirarchy"))
                attributes.Add("data-heirarchy", metadata.AdditionalValues["heirarchy"]);

            if (metadata.AdditionalValues.ContainsKey("methodName"))
                attributes.Add("data-method", metadata.AdditionalValues["methodName"]);

            if (metadata.AdditionalValues.ContainsKey("enumName"))
                attributes.Add("data-enum", metadata.AdditionalValues["enumName"]);

            attributes.Add("data-message", GetOptionText(metadata));
        }

        private static string GetOptionText(ModelMetadata metadata)
        {
            return "All " + metadata.GetDisplayName();
        }

        private static MvcHtmlString DropDownHelper<T>(this HtmlHelper<T> helper, ModelMetadata metadata, object model, IDictionary<string, object> attrs )
        {
            if (attrs == null)
                attrs = new Dictionary<string, object>();
            NormalizeAttributes(metadata, ref attrs);
            var enumerable = model as IEnumerable<string>;
            if (typeof(IEnumerable<string>).IsAssignableFrom(metadata.ModelType))
            {
                return PicklistHelper(helper, metadata, (IList<string>)model, attrs);     
            }

            var optionLabel = metadata.AdditionalValues.ContainsKey("option-label") ?
                            metadata.AdditionalValues["option-label"] != null ? metadata.AdditionalValues["option-label"].ToString() : null
                                          : null;
            attrs.Add("data-dropdown", "select");

            return helper.DropDownList("", helper.GetAutomatedList(metadata).SetSelected(model), optionLabel, attrs);
        }

        private static MvcHtmlString PicklistHelper<T>(this HtmlHelper<T> helper, ModelMetadata metadata, IList<string> model,
            IDictionary<string, object> attrs)
        {

            var isAllSelected = false;

            var name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName("");

            var outerDiv = new TagBuilder("div");

            attrs.Add("data-dropdown", "picklist");
            attrs.Add("data-dropdown-property", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(""));
            attrs.Add("data-dropdown-friendlyname", metadata.GetDisplayName());
            attrs.Add("data-click-outside-container", "true");

            outerDiv.MergeAttributes(attrs);

            // build header
            var headerDiv = new TagBuilder("div");
            headerDiv.AddCssClass("picklist-header");

            var headerText = new TagBuilder("span");
            

            var downCaret = new TagBuilder("i");
            downCaret.AddCssClass("icon-caret-down");

            var upCaret = new TagBuilder("i");
            upCaret.AddCssClass("icon-caret-up");

            // build the body
            var bodyDiv = new TagBuilder("div");
            bodyDiv.MergeAttribute("data-click-outside-behavior", "close");
            bodyDiv.AddCssClass("picklist-body");

            // build the search
            var searchInput = new TagBuilder("input");
            searchInput.MergeAttribute("data-dropdown-filter", "true");
            searchInput.AddCssClass("picklist-search");

            // build the inner (list)
            var innerDiv = new TagBuilder("div");
            innerDiv.AddCssClass("picklist-inner");

            // build select all option
            var selectAll = new TagBuilder("div");
            var selectAllCheckbox = new TagBuilder("input");

            selectAllCheckbox.MergeAttribute("type", "checkbox");
            selectAllCheckbox.MergeAttribute("data-dropdown-selectall", "true");
            selectAllCheckbox.MergeAttribute("value", "~");  
            selectAllCheckbox.MergeAttribute("name", name);

            if (model != null && model.Contains("~"))
            {
                selectAllCheckbox.MergeAttribute("checked", "checked");
                isAllSelected = true;
            }

            // render select all
            selectAll.InnerHtml += selectAllCheckbox.ToString(TagRenderMode.SelfClosing) + " Select All " +
                metadata.GetDisplayName();
            
            // build and render items from list
            // render inner div
            innerDiv.InnerHtml += selectAll.ToString(TagRenderMode.Normal);
            var itemCount = 0;
            var selectedItemCount = 0;
            foreach (var item in helper.GetAutomatedList(metadata))
            {
                itemCount++;
                var listRow = new TagBuilder("div");                   
                var checkbox = new TagBuilder("input");

                checkbox.MergeAttribute("type", "checkbox");
                checkbox.MergeAttribute("name", name);
                checkbox.MergeAttribute("value", item.Value);

                if (model != null && (model.Contains(item.Value) || isAllSelected))
                {
                    checkbox.MergeAttribute("checked", "checked");
                    selectedItemCount++;
                }
                
                // render item
                listRow.InnerHtml += checkbox.ToString(TagRenderMode.SelfClosing)  + item.Text;
                innerDiv.InnerHtml += listRow.ToString(TagRenderMode.Normal);
            }

            if (selectedItemCount > 0)
                headerText.SetInnerText(metadata.GetDisplayName() + " (" + itemCount.ToString() + " selected)");
            else
                headerText.SetInnerText("Select " + metadata.GetDisplayName());


            // render header
            headerDiv.InnerHtml += headerText.ToString(TagRenderMode.Normal);
            headerDiv.InnerHtml += downCaret.ToString(TagRenderMode.Normal);
            headerDiv.InnerHtml += upCaret.ToString(TagRenderMode.Normal);

            // render body
            bodyDiv.InnerHtml += searchInput.ToString(TagRenderMode.Normal);
            bodyDiv.InnerHtml += innerDiv.ToString(TagRenderMode.Normal);

            // render outer div
            outerDiv.InnerHtml += headerDiv.ToString(TagRenderMode.Normal);
            outerDiv.InnerHtml += bodyDiv.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(outerDiv.ToString(TagRenderMode.Normal));

        }
    }
}
