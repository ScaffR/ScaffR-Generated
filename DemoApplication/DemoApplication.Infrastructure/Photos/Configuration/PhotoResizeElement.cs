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
    /// The photo resize element.
    /// </summary>
    public class PhotoResizeElement : ConfigurationElement, IPhotoResize
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }

            set
            {
                base["name"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        [ConfigurationProperty("width")]
        public int Width
        {
            get
            {
                return (int)base["width"];
            }

            set
            {
                base["width"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        [ConfigurationProperty("height")]
        public int Height
        {
            get
            {
                return (int)base["height"];
            }

            set
            {
                base["height"] = value;
            }
        }
    }
}