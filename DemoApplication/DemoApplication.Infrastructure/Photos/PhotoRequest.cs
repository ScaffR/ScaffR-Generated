#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Photos
{
    #region

    using System.IO;
    using System.Web;
    using Core.Interfaces.Photos;

    #endregion

    /// <summary>
    /// The photo request.
    /// </summary>
    public class PhotoRequest : IPhotoRequest
    {
        /// <summary>
        /// Gets the stream.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Gets the mime type.
        /// </summary>
        public string MimeType { get; private set; }

        /// <summary>
        /// Gets the photo id.
        /// </summary>
        public string PhotoId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoRequest"/> class.
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <param name="mimeType">
        /// The mime type.
        /// </param>
        /// <param name="photoId">
        /// The photo id.
        /// </param>
        public PhotoRequest(Stream stream, string mimeType, string photoId)
        {
            Stream = stream;
            MimeType = mimeType;
            this.PhotoId = photoId;
        }

        public PhotoRequest(HttpPostedFileBase file, string photoId) : this(file.InputStream, file.ContentType, photoId)
        {
        }
    }
}