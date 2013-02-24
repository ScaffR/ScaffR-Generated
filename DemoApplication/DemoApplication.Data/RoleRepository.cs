namespace DemoApplication.Data
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Model;

    public partial class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
		public RoleRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}