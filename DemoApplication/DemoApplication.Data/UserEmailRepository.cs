namespace DemoApplication.Data
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Model;

    public partial class UserEmailRepository : BaseRepository<UserEmail>, IUserEmailRepository
    {
		public UserEmailRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}