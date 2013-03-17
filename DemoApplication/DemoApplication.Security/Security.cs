namespace DemoApplication.Security
{
    #region

    using Configuration;

    #endregion

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