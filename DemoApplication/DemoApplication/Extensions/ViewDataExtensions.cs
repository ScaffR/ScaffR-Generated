namespace DemoApplication.Extensions
{
    using System.Web.Mvc;

    public static class ViewDataExtensions
    {
        public static bool IsPropertyVisible(this ModelMetadata metadata, TemplateInfo template)
        {
            return !metadata.HideSurroundingHtml && metadata.ShowForEdit && !template.Visited(metadata);
        }
    }
}