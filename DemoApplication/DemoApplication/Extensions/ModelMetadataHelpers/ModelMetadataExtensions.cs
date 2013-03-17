#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-04-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.ModelMetadataHelpers
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