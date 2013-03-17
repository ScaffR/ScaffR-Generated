namespace DemoApplication.Infrastructure.Configuration.Photos
{
    #region

    using System;
    using System.Configuration.Provider;
    using Core.Common.Photos;

    #endregion

    /// <summary>
    /// The photo provider collection.
    /// </summary>
    public class PhotoProviderCollection : ProviderCollection
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
        public new PhotoProvider this[string name]
        {
            get
            {
                return (PhotoProvider)base[name];
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

            if (!(provider is PhotoProvider))
            {
                throw new ArgumentException("Invalid provider type", "provider");
            }

            base.Add(provider);
        }
    }
}