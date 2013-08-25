using System;
using System.Configuration.Provider;

namespace ParadiseBookers.Infrastructure.Storage
{
    public class StorageProviderCollection : ProviderCollection
    {
        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The JamesRocks.Photos.PhotoProvider.
        /// </returns>
        public new StorageProvider this[string name]
        {
            get
            {
                return (StorageProvider)base[name];
            }
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentException">
        /// </exception>
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (!(provider is StorageProvider))
            {
                throw new ArgumentException("Invalid provider type", "provider");
            }

            base.Add(provider);
        }
    }
}