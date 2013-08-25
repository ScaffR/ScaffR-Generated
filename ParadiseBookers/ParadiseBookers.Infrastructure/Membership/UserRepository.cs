#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using ParadiseBookers.Core.Interfaces.Data;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Infrastructure.Data;

namespace ParadiseBookers.Infrastructure.Membership
{
    #region

    

    #endregion

    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}