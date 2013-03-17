namespace DemoApplication.Infrastructure.Photos
{
    #region

    using System.Collections.Generic;
    using System.Configuration.Provider;
    using System.Web.Configuration;
    using Configuration;
    using Configuration.Photos;
    using Core.Common.Photos;

    #endregion

    /// <summary>
    /// The photo manager.
    /// </summary>
    public class PhotoManager
    {
        #region Provider-specific code

        /// <summary>
        /// The lock.
        /// </summary>
        private static readonly object Lock = new object();

        /// <summary>
        /// The _provider.
        /// </summary>
        private static PhotoProvider _provider;

        /// <summary>
        /// The _providers.
        /// </summary>
        private static PhotoProviderCollection _providers;

        /// <summary>
        /// The _photo resize.
        /// </summary>
        private static IDictionary<string, PhotoResize> _photoResize;

        /// <summary>
        /// Gets the provider.
        /// </summary>
        public static PhotoProvider Provider
        {
            get
            {
                LoadProviders();
                return _provider;
            }
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        public static PhotoProviderCollection Providers
        {
            get
            {
                LoadProviders();
                return _providers;
            }
        }

        /// <summary>
        /// Gets the photo resizes.
        /// </summary>
        public static IDictionary<string, PhotoResize> PhotoResizes
        {
            get
            {
                LoadProviders();
                return _photoResize;
            }
        }

        /// <summary>
        /// The load providers.
        /// </summary>
        /// <exception cref="ProviderException">
        /// </exception>
        private static void LoadProviders()
        {
            if (_provider == null)
            {
                lock (Lock)
                {
                    var section = AppConfig.Instance.Photos;

                    _providers = new PhotoProviderCollection();
                    ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(PhotoProvider));
                    _provider = _providers[section.DefaultProvider];

                    _photoResize = new Dictionary<string, PhotoResize>();

                    foreach (PhotoResizeElement photoResize in section.PhotoResizes)
                    {
                        _photoResize.Add(photoResize.Name, new PhotoResize(photoResize));
                    }

                    if (_provider == null)
                    {
                        throw new ProviderException("Unable to load default FileSystemProvider");
                    }
                }
            }
        }

        #endregion

        #region Provider methods

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
        public Photo SavePhotoResize(PhotoRequest item, string resizeName)
        {
            return Provider.SavePhotoResize(item, resizeName);
        }

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
        public IList<Photo> SavePhotoForAllSizes(PhotoRequest item, bool keepOriginalSize)
        {
            return Provider.SavePhotoForAllSizes(item, keepOriginalSize);
        }

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
        public Photo GetPhotoResize(string id, string resizeName)
        {
            return Provider.GetPhotoResize(id, resizeName);
        }

        /// <summary>
        /// The get all photo resizes.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IDictionary`2[TKey -&gt; System.String, TValue -&gt; JamesRocks.Photos.Models.Photo].
        /// </returns>
        public IDictionary<string, Photo> GetAllPhotoResizes(string id)
        {
            return Provider.GetAllPhotoResizes(id);
        }

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
        public IList<Photo> GetPhotosByResize(string resizeName, string[] ids)
        {
            return Provider.GetPhotosByResize(resizeName, ids);
        }

        #endregion
    }
}