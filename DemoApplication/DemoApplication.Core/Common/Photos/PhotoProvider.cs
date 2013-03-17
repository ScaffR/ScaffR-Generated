namespace DemoApplication.Core.Common.Photos
{
    #region

    using System.Collections.Generic;
    using System.Configuration.Provider;

    #endregion

    /// <summary>
    /// The photo provider.
    /// </summary>
    public abstract class PhotoProvider : ProviderBase
    {
        /// <summary>
        /// The save photo resize.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="resizeName">
        /// The resize name.
        /// </param>
        /// <returns>
        /// The JamesRocks.Photos.Models.Photo.
        /// </returns>
        public abstract Photo SavePhotoResize(PhotoRequest item, string resizeName);

        /// <summary>
        /// The save photo for all sizes.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="keepOriginalSize">
        /// The keep original size.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IList`1[T -&gt; JamesRocks.Photos.Models.Photo].
        /// </returns>
        public abstract IList<Photo> SavePhotoForAllSizes(PhotoRequest item, bool keepOriginalSize);

        /// <summary>
        /// The get photo resize.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="resizeName">
        /// The resize name.
        /// </param>
        /// <returns>
        /// The JamesRocks.Photos.Models.Photo.
        /// </returns>
        public abstract Photo GetPhotoResize(string id, string resizeName);

        /// <summary>
        /// The get all photo resizes.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IDictionary`2[TKey -&gt; System.String, TValue -&gt; JamesRocks.Photos.Models.Photo].
        /// </returns>
        public abstract IDictionary<string, Photo> GetAllPhotoResizes(string id);

        /// <summary>
        /// The get photos by resize.
        /// </summary>
        /// <param name="resizeName">
        /// The resize name.
        /// </param>
        /// <param name="ids">
        /// The ids.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IList`1[T -&gt; JamesRocks.Photos.Models.Photo].
        /// </returns>
        public abstract IList<Photo> GetPhotosByResize(string resizeName, string[] ids);
    }
}