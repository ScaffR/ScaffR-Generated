#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.ModelMetadataHelpers
{
    #region

    using System.Web.Mvc;

    #endregion

    public static partial class ModelMetadataExtensions
    {
        /// <summary>
        /// Determines whether [is property visible] [the specified metadata].
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="template">The template.</param>
        /// <returns><c>true</c> if [is property visible] [the specified metadata]; otherwise, <c>false</c>.</returns>
        public static bool IsPropertyVisible(this ModelMetadata metadata, TemplateInfo template)
        {
            return !metadata.HideSurroundingHtml && metadata.ShowForEdit && !template.Visited(metadata);
        }

        /// <summary>
        /// Determines whether [is property bool] [the specified meta].
        /// </summary>
        /// <param name="meta">The meta.</param>
        /// <returns><c>true</c> if [is property bool] [the specified meta]; otherwise, <c>false</c>.</returns>
        public static bool IsPropertyBool(this ModelMetadata meta)
        {
            return meta.ModelType == typeof(bool) || meta.ModelType == typeof(bool?);
        }
    }
}