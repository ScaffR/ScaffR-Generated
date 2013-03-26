#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Membership
{
    #region

    using Core.Interfaces.Data;
    using Core.Model;
    using Data;

    #endregion

    /// <summary>
    /// Class UserClaimRepository
    /// </summary>
    public partial class UserClaimRepository : BaseRepository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}