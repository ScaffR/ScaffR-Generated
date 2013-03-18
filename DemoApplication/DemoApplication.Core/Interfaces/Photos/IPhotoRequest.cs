#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Photos
{
    #region

    using System.IO;

    #endregion

    public interface IPhotoRequest
    {
        /// <summary>
        /// Gets the stream.
        /// </summary>
        Stream Stream { get; }

        /// <summary>
        /// Gets the mime type.
        /// </summary>
        string MimeType { get; }

        /// <summary>
        /// Gets the photo id.
        /// </summary>
        string PhotoId { get; }
    }
}