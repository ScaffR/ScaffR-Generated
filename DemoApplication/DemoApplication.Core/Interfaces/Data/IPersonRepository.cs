namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using Model;

    #endregion

    public partial interface IPersonRepository : IRepository<Person>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
