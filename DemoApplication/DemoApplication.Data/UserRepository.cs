namespace DemoApplication.Data
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Model;

    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
		public UserRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}