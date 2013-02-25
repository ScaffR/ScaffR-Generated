namespace DemoApplication.Core.Interfaces.Service
{
    using Model;

    public partial interface IUserService : IService<User>
    {
		// Add extra serviceinterface methods in a partial interface
	}
}