#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
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

    public partial class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
		public RoleRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}