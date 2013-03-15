namespace DemoApplication.Security
{
    using Configuration;
    using DemoApplication.Core.Configuration;

    public partial class Security
    {

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