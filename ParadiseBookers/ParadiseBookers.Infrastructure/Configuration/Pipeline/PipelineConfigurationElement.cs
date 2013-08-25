#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Configuration;
using ParadiseBookers.Core.Interfaces.Pipeline;

namespace ParadiseBookers.Infrastructure.Configuration.Pipeline
{
    #region

    

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
