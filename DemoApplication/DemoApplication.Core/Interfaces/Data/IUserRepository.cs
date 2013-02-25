namespace DemoApplication.Core.Interfaces.Data
{
    using Model;

    public partial interface IUserRepository : IRepository<User>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
