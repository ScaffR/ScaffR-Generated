using System.Collections.Generic;
using System.Configuration.Provider;
using System.Web;
using System.Web.Configuration;
using ParadiseBookers.Infrastructure.Configuration;

namespace ParadiseBookers.Infrastructure.Storage
{
    public static class StorageManager
    {
        /// <summary>
        /// The lock.
        /// </summary>
        private static readonly object Lock = new object();

        /// <summary>
        /// The _provider.
        /// </summary>
        private static StorageProvider _provider;

        /// <summary>
        /// The _providers.
        /// </summary>
        private static StorageProviderCollection _providers;


        /// <summary>
        /// Gets the provider.
        /// </summary>
        public static StorageProvider Provider
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
        public static StorageProviderCollection Providers
        {
            get
            {
                LoadProviders();
                return _providers;
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
                    var section = AppConfig.Instance.Storage;

                    _providers = new StorageProviderCollection();
                    ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(StorageProvider));
                    _provider = _providers[section.DefaultProvider];

                    if (_provider == null)
                    {
                        throw new ProviderException("Unable to load default StorageProvider");
                    }
                }
            }
        }

        public static void UploadPartialFile(string fileName, HttpContext context, List<FilesStatus> statuses)
        {
            Provider.UploadPartialFile(fileName, context, statuses);
        }

        public static void UploadWholeFile(HttpContext context, List<FilesStatus> statuses)
        {
            Provider.UploadWholeFile(context, statuses);
        }

        public static void UploadFile(HttpContext context)
        {
            Provider.UploadFile(context);
        }

        public static void DeliverFile(HttpContext context)
        {
            Provider.DeliverFile(context);
        }

        public static void DeleteFile(HttpContext context)
        {
            Provider.DeleteFile(context);
        }

        public static void ListCurrentFiles(HttpContext context)
        {
            Provider.DeliverFile(context);
        }

        public static FilesStatus UploadSingleFile(HttpPostedFile file)
        {
            return Provider.UploadSingleFile(file);
        }
    }
}
