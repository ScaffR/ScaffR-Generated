namespace DemoApplication.Extensions
{
    using System.Web.Mvc;
    using Core.Model;

    public static partial class UrlExtensions
    {
        public static string ProfilePicture(this UrlHelper url, string photoId, string resize, Gender gender)
        {            
            string defaultUrl = string.Format("~/Content/images/{0}/{1}.jpg", resize, gender.ToString());

            return PhotoHelpers.GetPhotoUrl(url, photoId, resize, defaultUrl);
        }
      
    }
}