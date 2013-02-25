namespace DemoApplication.Data
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Model;

    public partial class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
		public UserRoleRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}