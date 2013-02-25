namespace DemoApplication.Core.Common.Membership
{
    using Configuration;
    using Configuration.Membership;

    public partial class MembershipManager
    {
        private static MembershipManager _instance;
        private MembershipElement _configuration;

        public static MembershipManager Instance
        {
            get { return _instance ?? (_instance = new MembershipManager(CoreSection.GetConfig().Membership)); }
        }

        private MembershipManager(MembershipElement configuration)
        {
            _configuration = configuration;
        }
    }
}
