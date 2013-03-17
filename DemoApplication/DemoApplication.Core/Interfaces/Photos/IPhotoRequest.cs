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