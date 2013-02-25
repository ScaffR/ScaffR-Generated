namespace DemoApplication.Infrastructure.Configuration.Pipeline
{
    using System.Configuration;

    public class PipelineConfigurationElement : ConfigurationElement
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
