#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Configuration.Pipeline
{
    #region

    using System.Configuration;
    using Core.Interfaces.Pipeline;

    #endregion

    public class PipelineConfigurationElement : ConfigurationElement, IPipelineSettings
    {
        [ConfigurationProperty("processor", IsRequired = false)]
        public string ProcessorType
        {
            get { return (string)base["processor"]; }
        }

        [ConfigurationProperty("filters", IsDefaultCollection = false)]       
        public ProviderSettingsCollection Filters
        {
            get { return (ProviderSettingsCollection)this["filters"]; }
        }
    }
}
