#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using DemoApplication.Infrastructure.Configuration.Storage;

namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Photos;

    #endregion

    public partial class AppConfig
    {
        [ConfigurationProperty("photos", IsRequired = true)]
        public PhotoElement Photos
        {
            get
            {
                return (PhotoElement)base["photos"];
            }
        }
    }


}
