namespace DemoApplication.Extensions
{
    using System.Web.Mvc;
    using Core.Common.Photos;

    public static class PhotoHelpers
    {
        public static string GetPhotoUrl(this UrlHelper helper, string imageId, string size, string defaultUrl = null)
        {
            var photo = PhotoManager.Provider.GetPhotoResize(imageId, size);
            if (photo != null)
            {
                return helper.Content(photo.Url);
            }
            return defaultUrl != null ? helper.Content(defaultUrl) : "";
        }
    }
}