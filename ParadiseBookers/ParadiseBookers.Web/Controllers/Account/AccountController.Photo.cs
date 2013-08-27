#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ParadiseBookers.Core.Common.Photos;
using ParadiseBookers.Infrastructure.Photos;
using ParadiseBookers.Infrastructure.Profiles;

namespace ParadiseBookers.Controllers.Account
{
    #region

    

    #endregion

    /// <summary>
    /// Class AccountController
    /// </summary>
    public partial class AccountController
    {
        /// <summary>
        /// Update the profile photo.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Photo()
        {
            if (!string.IsNullOrWhiteSpace(UserProfile.Current.PhotoId))
            {
                var photo = PhotoManager.Provider.GetPhotoResize(UserProfile.Current.PhotoId, "Medium");
                return View(photo);
            }

            return View(new Photo { Url = Url.Content("~/Content/images/Medium/Male.jpg") });
        }

        /// <summary>
        /// Update/Remove the profile photo.
        /// </summary>
        /// <param name="button">The button value</param>
        /// <param name="file">The file.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Photo(string button, HttpPostedFileBase file)
        {
            switch (button)
            {
                case "Remove":
                    {
                        #region REMOVE PHOTO

                        IDictionary<string, Photo> photoSizes =
                            PhotoManager.Provider.GetAllPhotoResizes(UserProfile.Current.PhotoId);

                        foreach (var photoSize in photoSizes)
                            System.IO.File.Delete(Server.MapPath(photoSize.Value.Url));

                        UserProfile.Current.PhotoId = null;
                        _userService.SetProfilePicture(UserProfile.Current.Tenant, UserProfile.Current.Username, null);

                        break;

                        #endregion
                    }
                case "Upload":
                    {
                        #region UPLOAD PHOTO

                        if (file != null)
                        {
                            // GET UPLOAD PHOTO REQUEST
                            var request = new PhotoRequest(file.InputStream, "image/png", null);

                            // UPLOAD PHOTO TO SERVER
                            var photoResult = PhotoManager.Provider.SavePhotoForAllSizes(request, true);

                            // VALIDATE PHOTO WAS UPLOADED TO SERVER
                            if (photoResult != null && photoResult.Count > 0)
                            {
                                var photo = PhotoManager.Provider.GetPhotoResize(photoResult[0].Id, "Medium");

                                // SAVE PHOTOID ON ACCOUNT
                                if (photo != null &&
                                    _userService.SetProfilePicture(UserProfile.Current.Tenant,
                                                                   UserProfile.Current.Username,
                                                                   photo.Id))
                                {
                                    // DELETE ALL SIZES OF OLD PHOTO
                                    if (!string.IsNullOrEmpty(UserProfile.Current.PhotoId))
                                    {
                                        IDictionary<string, Photo> photoSizes =
                                            PhotoManager.Provider.GetAllPhotoResizes(UserProfile.Current.PhotoId);

                                        foreach (var photoSize in photoSizes)
                                            System.IO.File.Delete(Server.MapPath(photoSize.Value.Url));
                                    }

                                    // ASSIGN NEW PHOTOID TO CURRENT USER AND RETURN VIEW
                                    UserProfile.Current.PhotoId = photo.Id;
                                    return View(photo);
                                }
                            }
                        }
                        else
                        {
                            // IF USER HAS A PHOTOID SET, DISPLAY IT
                            if (!string.IsNullOrWhiteSpace(UserProfile.Current.PhotoId))
                            {
                                var photo = PhotoManager.Provider.GetPhotoResize(UserProfile.Current.PhotoId, "Medium");
                                return View(photo);
                            }
                        }
                        break;

                        #endregion
                    }
            }

            return View(new Photo { Url = Url.Content("~/Content/images/Medium/Male.jpg") });
        }
    }
}