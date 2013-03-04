namespace DemoApplication.Models.Attributes
{
    using System;
    using System.Web.Mvc;

    public class HideSurroundingChromeAttribute : Attribute, IMetadataAware
    {
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("HideSurroundingChrome", new object());
        }
    }

    public static class HideSurroundingChromeHelpers
    {
        public static bool HideSurroundingChrome(this ModelMetadata metadata)
        {
            return metadata.AdditionalValues.ContainsKey("HideSurroundingChrome");
        }
    }
}