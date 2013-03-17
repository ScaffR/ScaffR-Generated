﻿#region credits
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
    using System.Web.Mvc;
    using Core.Extensions;
    using Metadata.Attributes;
    using ModelMetadataHelpers;

    #endregion

    public static partial class HtmlExtensions
    {
        /// <summary>
        /// Gets the textbox attributes.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="classesToAdd">The classes to add.</param>
        /// <returns>IDictionary{System.StringSystem.Object}.</returns>
        public static IDictionary<string, object> GetTextboxAttributes(this HtmlHelper helper,
            params string[] classesToAdd)
        {
            return helper.GetTextboxAttributes(null, classesToAdd);
        }

        /// <summary>
        /// Gets the textbox attributes.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="type">The type.</param>
        /// <param name="classesToAdd">The classes to add.</param>
        /// <returns>IDictionary{System.StringSystem.Object}.</returns>
        public static IDictionary<string, object> GetTextboxAttributes(this HtmlHelper helper, string type, params string[] classesToAdd)
        {
            var options = helper.ViewData.ModelMetadata.GetOptions();

            var attrs = new Dictionary<string, object>();
            var classes = new List<string> { "text-box" };

            if (!string.IsNullOrEmpty(type))
            {
                attrs.Add("type", type);
            }

            classes.AddRange(classesToAdd);

            if (helper.ViewData.ModelMetadata.IsReadOnly)
                attrs.Add("disabled", "true");

            // add any data- attributes from additional data
            foreach (var data in helper.ViewData.ModelMetadata.AdditionalValues)
                if (data.Key.StartsWith("data-", StringComparison.InvariantCultureIgnoreCase))
                    attrs.Add(data.Key, data.Value);

            if (helper.ViewData.ModelMetadata.IsRequired)
                classes.Add("required");

            if (options != null)
            {
                classes.Add(options.Multiline ? "multi-line" : "single-line");

                if (!string.IsNullOrEmpty(options.Placeholder))
                    attrs.Add("placeholder", options.Placeholder);

                if (!string.IsNullOrEmpty(options.Mask))
                    attrs.Add("data-mask", options.Mask);

                attrs.Add("data-focus-behavior", options.FocusBehavior);

                if (options.Size == TextboxSize.None)
                    options.Size = TextboxSize.XLarge;

                classes.Add(options.Size.GetDescription());
            }

            attrs.Add("class", String.Join(" ", classes));
            attrs.Add("autocomplete", "false");

            return attrs;
        }
    }
}