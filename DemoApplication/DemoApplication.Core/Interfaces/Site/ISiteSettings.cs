#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Site
{
    #region

    using System;
    using System.Configuration;

    #endregion

    public interface ISiteSettings
    {
        [ConfigurationProperty("instanceId")]
        Guid InstanceId { get; set; }

        [ConfigurationProperty("version")]
        string Version { get; set; }

        [ConfigurationProperty("email", IsRequired = true)]
        string EmailAddress { get; set; }

        [ConfigurationProperty("companyName", IsRequired = true)]
        string CompanyName { get; set; }

        [ConfigurationProperty("websiteName", IsRequired = true)]
        string WebsiteName { get; set; }
    }
}