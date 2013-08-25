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

using System.Configuration;
using ParadiseBookers.Infrastructure.Configuration.Site;

namespace ParadiseBookers.Infrastructure.Configuration
{
    #region

    

    #endregion

    public partial class AppConfig
    {
        [ConfigurationProperty("site", IsRequired = true)]
        public SiteElement Site
        {
            get
            {
                return (SiteElement)base["site"];
            }
        }
    }
}
