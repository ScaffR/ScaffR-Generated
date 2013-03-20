#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Photos.Configuration
{
    #region

    using System.Configuration;
    using Core.Interfaces.Photos;

    #endregion

    /// <summary>
    /// The photo section.
    /// </summary>
    public class PhotoElement : ConfigurationElement, IPhotoSettings
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base["providers"];
            }
        }

        /// <summary>
        /// Gets or sets the default provider.
        /// </summary>
        [StringValidator(MinLength = 1)]
        [ConfigurationProperty("defaultProvider", DefaultValue = "SqlProvider")]
        public string DefaultProvider
        {
            get
            {
                return (string)base["defaultProvider"];
            }

            set
            {
                base["defaultProvider"] = value;
            }
        }

        /// <summary>
        /// Gets the photo resizes.
        /// </summary>
        [ConfigurationProperty("PhotoResize")]
        public PhotoResizeCollection PhotoResizes
        {
            get
            {
                return (PhotoResizeCollection)base["PhotoResize"];
            }
        }
    }
}