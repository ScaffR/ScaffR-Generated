namespace DemoApplication.Security.Configuration
{
    using System.Configuration;

    public partial class SecurityElement : ConfigurationElement
    {
        [ConfigurationProperty("securityLevel", IsRequired = true)]
        public SecurityLevel SecurityLevel
        {
            get { return (SecurityLevel)base["securityLevel"]; }
            set { base["securityLevel"] = value; }
        }
    }
}
