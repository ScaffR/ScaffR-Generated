#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.UrlHelpers
{
    #region

    using System.Web.Mvc;
    using Core.Model;

    #endregion

    public static partial class UrlExtensions
    {
        public static string ProfilePicture(this UrlHelper url, string photoId, string resize, Gender gender)
        {            
            string defaultUrl = string.Format("~/Content/images/{0}/{1}.jpg", resize, gender.ToString());

            return GetPhotoUrl(url, photoId, resize, defaultUrl);
        }
      
    }
}