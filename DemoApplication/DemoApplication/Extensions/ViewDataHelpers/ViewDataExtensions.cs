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
namespace DemoApplication.Extensions.ViewDataHelpers
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