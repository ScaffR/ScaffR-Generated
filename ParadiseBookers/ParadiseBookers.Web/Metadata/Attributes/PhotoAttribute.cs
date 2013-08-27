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

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ParadiseBookers.Metadata.Attributes
{
    #region

    

    #endregion

    public class PhotoAttribute : UIHintAttribute, IMetadataAware
    {
        private readonly string _size;

        public PhotoAttribute(string size) : base("Photo")
        {
            _size = size;
        }

        public string DefaultUrl { get; set; }


        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["size"] = _size;
            metadata.AdditionalValues["defaulturl"] = this.DefaultUrl ?? "~/content/images/no-photo.jpg";
        }
    }
}