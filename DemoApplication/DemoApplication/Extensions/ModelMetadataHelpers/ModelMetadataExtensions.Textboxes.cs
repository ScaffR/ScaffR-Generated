#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.ModelMetadataHelpers
{
    #region

    using System.Web.Mvc;
    using HtmlHelpers;

    #endregion

    public static partial class ModelMetadataExtensions
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns>BootstrapInputOptions.</returns>
        public static BootstrapInputOptions GetOptions(this ModelMetadata metadata)
        {
            object options;

            metadata.AdditionalValues.TryGetValue("InputOptions", out options);

            return (BootstrapInputOptions)options;
        }
    }
}