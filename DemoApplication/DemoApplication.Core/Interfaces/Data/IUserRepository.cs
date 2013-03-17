namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using Model;

    #endregion

    public partial interface IUserRepository : IRepository<User>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
