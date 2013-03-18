#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;
    using Membership;

    #endregion

    public partial class AppConfig
    {
        [ConfigurationProperty("membership", IsRequired = false)]
        public MembershipElement Membership
        {
            get
            {
                return (MembershipElement)base["membership"];
            }
        }
    }
}
