namespace DemoApplication.Extensions
{
    #region

    using System.Web.Mvc;

    #endregion

    public static class ViewDataExtensions
    {
        public static bool IsPropertyVisible(this ModelMetadata metadata, TemplateInfo template)
        {
            return !metadata.HideSurroundingHtml && metadata.ShowForEdit && !template.Visited(metadata);
        }
    }
}