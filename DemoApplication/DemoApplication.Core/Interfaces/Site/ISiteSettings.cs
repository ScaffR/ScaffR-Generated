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