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
