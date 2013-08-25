#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Web.Mvc;

namespace ParadiseBookers.Metadata.Attributes
{
    #region

    

    #endregion

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
            return metadata.AdditionalValues.ContainsKey("HideSurroundingChrome") || metadata.HideSurroundingHtml;
        }
    }
}