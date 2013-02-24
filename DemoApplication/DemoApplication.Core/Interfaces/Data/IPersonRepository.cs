namespace DemoApplication.Core.Interfaces.Data
{
    using Model;

    public partial interface IPersonRepository : IRepository<Person>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
