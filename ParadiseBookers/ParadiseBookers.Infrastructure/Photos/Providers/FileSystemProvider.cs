#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using ParadiseBookers.Core.Common.Photos;
using ParadiseBookers.Core.Interfaces.Photos;

namespace ParadiseBookers.Infrastructure.Photos.Providers
{
    #region

    

    #endregion

    public class FileSystemProvider : PhotoProvider
    {
        private string _filePath;

        private const string SearchPattern = ".bmp,.gif,.jpg,.jpeg,.png";

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            _filePath = config["imageFolder"];
            if (string.IsNullOrEmpty(_filePath))
            {
                throw new ProviderException("Empty or missing 'imageFolder' value");
            }

            config.Remove("imageFolder");

            if (config.Count > 0)
            {
                var attr = config.GetKey(0);
                if (!string.IsNullOrWhiteSpace(attr))
                {
                    throw new ProviderException("Unrecognized attribute: " + attr);
                }
            }
        }

        #region Overrides of PhotoProvider

        public override Photo SavePhotoResize(IPhotoRequest item, string resizeName)
        {
            // todo: if resizeName doesn't exist, then we need to throw an exception
            var photoResize = PhotoManager.PhotoResizes[resizeName];

            using (var stream = item.Stream)
            {
                string extension = GetExtension(item.MimeType);
                string name = string.Format("{0}{1}", DateTime.UtcNow.ToString("dd_MM_yyyy_hh_mm_ss_ffff"), extension);
                var photo = SaveImage(
                    stream, photoResize.Width, photoResize.Height, resizeName, name, item.MimeType ?? "image/jpeg");

                return photo;
            }
        }

        public override IList<Photo> SavePhotoForAllSizes(IPhotoRequest item, bool keepOriginalSize)
        {
            var photoResizes = PhotoManager.PhotoResizes;

            using (var stream = item.Stream)
            {
                string extension = GetExtension(item.MimeType);
                string name = string.Format("{0}{1}", DateTime.UtcNow.ToString("dd_MM_yyyy_hh_mm_ss_ffff"), extension);

                List<Photo> photos =
                    photoResizes.Select(
                        resize =>
                        SaveImage(
                            stream,
                            resize.Value.Width,
                            resize.Value.Height,
                            resize.Key,
                            name,
                            item.MimeType ?? "image/jpeg")).ToList();

                if (keepOriginalSize)
                {
                    using (Image image = Image.FromStream(stream))
                    {
                        var photo = SaveImage(
                            stream, image.Width, image.Height, null, name, item.MimeType ?? "image/jpeg");
                        photos.Add(photo);
                    }
                }

                return photos;
            }
        }

        public override Photo GetPhotoResize(string id, string resizeName)
        {
            var photo = GetPhoto(id, resizeName);

            return photo;
        }

        public override IDictionary<string, Photo> GetAllPhotoResizes(string id)
        {
            var photoResizes = PhotoManager.PhotoResizes;
            var photos = new Dictionary<string, Photo>();

            foreach (var resize in photoResizes)
            {
                var photo = GetPhoto(id, resize.Key);

                if (photo != null)
                {
                    photos.Add(resize.Key, photo);
                }
            }

            var originalPhoto = GetPhoto(id, null);

            if (originalPhoto != null)
            {
                photos.Add("original", originalPhoto);
            }

            return photos;
        }

        public override IList<Photo> GetPhotosByResize(string resizeName, string[] ids)
        {
            string physicalPath = System.Web.HttpContext.Current.Server.MapPath(_filePath);

            if (!string.IsNullOrWhiteSpace(resizeName))
            {
                physicalPath = Path.Combine(physicalPath, resizeName);
            }

            string resizeFolder = resizeName != null ? string.Format("{0}/", resizeName) : string.Empty;

            // todo: @rsanjar: Add a comment here on what this code is doing.  I think the forula for getting an Id should be in it's own function
            var photos =
                GetFilesByExtensions(physicalPath, SearchPattern.Split(',')).Where(
                    c => ids.Contains(c.Name.Split('.')[0])).Select(
                        c =>
                        new Photo
                        {
                            Id = c.Name,
                            ResizeName = resizeName,
                            Url = string.Format("{0}/{1}{2}", _filePath.TrimEnd('/'), resizeFolder, c.Name)
                        }).ToList();

            return photos;
        }

        #endregion

        #region private methods

        private Photo SaveImage(
            Stream stream,
            int width,
            int height,
            string resizeName,
            string imageFileName,
            string mimeType = "image/jpeg")
        {
            string physicalPath = System.Web.HttpContext.Current.Server.MapPath(_filePath);

            if (!string.IsNullOrWhiteSpace(resizeName))
            {
                physicalPath = Path.Combine(physicalPath, resizeName);
            }

            // Create a directory for the specified resizeName if not exists
            if (!Directory.Exists(physicalPath))
            {
                Directory.CreateDirectory(physicalPath);
                GrantAccess(physicalPath);
            }

            string fileName = Path.Combine(physicalPath, imageFileName);

            using (var resizedImage = ImageHelper.ResizeImage(stream, width, height))
            {
                ImageHelper.SaveImage(fileName, resizedImage, 90, mimeType);
            }

            // todo: again, need to isolate the logic to get file path, shouldn't be part of this function
            string extension = GetExtension(mimeType);
            string resizeFolder = resizeName != null ? string.Format("{0}/", resizeName) : string.Empty;

            var photo = new Photo
            {
                Id = imageFileName.Replace(extension, string.Empty).Trim('.'),
                ResizeName = resizeName,
                Url = string.Format("{0}/{1}{2}", _filePath.TrimEnd('/'), resizeFolder, imageFileName)
            };

            return photo;
        }

        private Photo GetPhoto(string id, string resizeName)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            Photo photo = null;
            string physicalPath = System.Web.HttpContext.Current.Server.MapPath(_filePath);

            if (!string.IsNullOrWhiteSpace(resizeName))
            {
                physicalPath = Path.Combine(physicalPath, resizeName);
            }


            if (Directory.Exists(physicalPath))
            {
                var path = Path.Combine(physicalPath, id);

                // todo: need to throw exception if file doesnt exist at all..
                var file = new FileInfo(path);

                // if id doesn't contain extension then search by file name
                if (!file.Exists)
                {
                    file = new DirectoryInfo(physicalPath).GetFiles().FirstOrDefault(c => c.Name.StartsWith(id));
                }

                if (file != null)
                {
                    string resizeFolder = resizeName != null ? string.Format("{0}/", resizeName) : string.Empty;
                    string virtualImagePath = string.Format("{0}/{1}{2}", _filePath.TrimEnd('/'), resizeFolder, file.Name);

                    photo = new Photo { Id = file.Name.Split('.')[0], ResizeName = resizeName, Url = virtualImagePath };
                }
            }

            return photo;
        }

        private void GrantAccess(string fullPath)
        {
            var directoryInfo = new DirectoryInfo(fullPath);

            var directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                    "everyone",
                    FileSystemRights.FullControl,
                    InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                    PropagationFlags.NoPropagateInherit,
                    AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }

        private IEnumerable<FileInfo> GetFilesByExtensions(string path, params string[] extensions)
        {
            var dirInfo = new DirectoryInfo(path);

            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

            var photos = dirInfo.GetFiles().Where(f => allowedExtensions.Contains(f.Extension));

            return photos;
        }

        private string GetExtension(string mimeType, string defaultExtension = ".jpeg")
        {
            // todo: need to isolate the logic here for parsing the value
            string extension = mimeType.Split('/').Length > 1 ? mimeType.Split('/')[1] : defaultExtension;
            extension = string.Format(".{0}", extension.Trim('.'));

            if (!SearchPattern.Split(',').Contains(extension))
            {
                extension = ".jpeg";
            }

            return extension;
        }

        #endregion
    }
}