namespace DemoApplication.Extensions
{
    using System.Web.Mvc;

    public static class ModelMetadataExtensions
    {
        public static bool IsPropertyBool(this ModelMetadata meta)
        {
            return meta.ModelType == typeof(bool) || meta.ModelType == typeof(bool?);
        }
    }
}