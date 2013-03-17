namespace DemoApplication.Core.Common.Membership
{
    #region

    using Interfaces.Membership;

    #endregion

    public partial class MembershipManager
    {
        private static MembershipManager _instance;
        private IMembershipSettings _configuration;

        private MembershipManager(IMembershipSettings configuration)
        {
            _configuration = configuration;
        }
    }
}
