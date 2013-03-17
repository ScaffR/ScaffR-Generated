namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using Model;

    #endregion

    public partial interface IUserEmailRepository : IRepository<UserEmail>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
