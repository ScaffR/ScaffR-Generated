namespace DemoApplication.Extensions
{
    #region

    using System.Web.Mvc;

    #endregion

    public static class InputExtensions
    {       
        public static BootstrapInputOptions GetOptions(this ModelMetadata metadata)
        {
            object options;

            metadata.AdditionalValues.TryGetValue("InputOptions", out options);

            return (BootstrapInputOptions)options;
        }
    }
}