namespace DemoApplication.Infrastructure.Configuration.Membership
{
    #region

    using System.Configuration;
    using Core.Interfaces.Membership;

    #endregion

    public partial class MembershipSettings : ConfigurationElement, IMembershipSettings
    {
    }
}
