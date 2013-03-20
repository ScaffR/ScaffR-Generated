#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Photos
{
    #region

    using System.Configuration;

    #endregion

    public interface IPhotoResize
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ConfigurationProperty("name")]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        [ConfigurationProperty("width")]
        int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        [ConfigurationProperty("height")]
        int Height { get; set; }
    }
}