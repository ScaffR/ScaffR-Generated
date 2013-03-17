namespace DemoApplication.Extensions
{
    #region

    using System.Web.Mvc;

    #endregion

    public static class ModelMetadataExtensions
    {
        public static bool IsPropertyBool(this ModelMetadata meta)
        {
            return meta.ModelType == typeof(bool) || meta.ModelType == typeof(bool?);
        }
    }
}