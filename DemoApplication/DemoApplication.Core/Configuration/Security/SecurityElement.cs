namespace DemoApplication.Core.Configuration.Security
{
    using System.Configuration;
    using Common.Security;

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
