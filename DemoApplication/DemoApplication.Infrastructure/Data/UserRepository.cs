namespace DemoApplication.Infrastructure.Data
{
    #region

    using Core.Interfaces.Data;
    using Core.Model;

    #endregion

    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
		public UserRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}