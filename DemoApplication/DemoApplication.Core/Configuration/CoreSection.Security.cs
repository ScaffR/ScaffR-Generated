namespace DemoApplication.Core.Configuration
{
    using System.Configuration;
    using Security;

    public partial class CoreSection
    {
        [ConfigurationProperty("security", IsRequired = true)]
        public SecurityElement Security
        {
            get
            {
                return (SecurityElement)base["security"];
            }
        }
    }
}
