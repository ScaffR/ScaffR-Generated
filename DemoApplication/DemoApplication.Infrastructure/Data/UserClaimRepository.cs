#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-18-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Data
{
    #region

    using Core.Interfaces.Data;
    using Core.Model;

    #endregion

    public partial class UserClaimRepository : BaseRepository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}