namespace DemoApplication.Core.Interfaces.Service
{
    #region

    using Model;

    #endregion

    public partial interface IUserService : IService<User>
    {
		// Add extra serviceinterface methods in a partial interface
	}
}