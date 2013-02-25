namespace DemoApplication.Core.Common.Security
{
    using Configuration;
    using Configuration.Security;

    public partial class Security
    {
        public static Security Instance
        {
            get
            {
                return new Security(CoreSection.GetConfig().Security);
            }
        }

        private readonly SecurityElement _config;

        public Security(SecurityElement config)
        {
            _config = config;
        }

        public SecurityLevel SecurityLevel
        {
            get { return _config.SecurityLevel; }
        }
    }
}