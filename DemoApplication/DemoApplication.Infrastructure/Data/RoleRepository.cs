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