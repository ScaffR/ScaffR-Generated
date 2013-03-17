namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using Model;

    #endregion

    public partial interface IRoleRepository : IRepository<Role>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
