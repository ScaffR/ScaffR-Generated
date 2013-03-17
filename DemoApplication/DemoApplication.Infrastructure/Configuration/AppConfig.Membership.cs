namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Membership;

    #endregion

    public partial class AppConfig
    {
        [ConfigurationProperty("membership", IsRequired = false)]
        public MembershipSettings Membership
        {
            get
            {
                return (MembershipSettings)base["membership"];
            }
        }
    }
}
