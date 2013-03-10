namespace DemoApplication.Extensions.Html
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Metadata.Attributes;

    public static partial class HtmlExtensions
	{
		public static IDictionary<string, object> GetTextboxAttributes(this HtmlHelper helper, params string[] classesToAdd)
		{
            var attrs = new Dictionary<string, object>();
            var classes = new List<string> { "text-box" };
		    foreach (var c in classesToAdd)
		    {
		        classes.Add(c);
		    }

            bool multiline = false;

            if (helper.ViewData.ModelMetadata.IsReadOnly)
            {
                attrs.Add("disabled", "true");
            }

            if (helper.ViewData.ModelMetadata.AdditionalValues.ContainsKey("multiline"))
            {
                Boolean.TryParse(helper.ViewData.ModelMetadata.AdditionalValues["multiline"].ToString(), out multiline);
                classes.Add("multi-line");
            }
			else
            {
                classes.Add("single-line");
            }

            if (helper.ViewData.ModelMetadata.IsRequired)
            {
                classes.Add("required");
            }

            if (helper.ViewData.ModelMetadata.AdditionalValues.ContainsKey("placeholder"))
            {
                attrs.Add("placeholder", helper.ViewData.ModelMetadata.AdditionalValues["placeholder"] as string);
            }

            if (helper.ViewData.ModelMetadata.AdditionalValues.ContainsKey("textbox-size"))
            {
                classes.Add("input-" + ((TextboxSize)helper.ViewData.ModelMetadata.AdditionalValues["textbox-size"]).ToString().ToLower());
            }

            if (helper.ViewData.ModelMetadata.AdditionalValues.ContainsKey("mask"))
            {
                attrs.Add("data-mask", helper.ViewData.ModelMetadata.AdditionalValues["mask"] as string);
            }

            if (helper.ViewData.ModelMetadata.AdditionalValues.ContainsKey("focus-behavior"))
            {
                attrs.Add("data-focus-behavior", helper.ViewData.ModelMetadata.AdditionalValues["focus-behavior"] as string);
            }

            //attrs.Add("type", "email");
            attrs.Add("class", String.Join(" ", classes));
            attrs.Add("autocomplete", "false");

		    return attrs;
		}
	}
}