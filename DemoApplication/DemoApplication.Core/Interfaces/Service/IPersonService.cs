namespace DemoApplication.Core.Interfaces.Service
{
    using Model;

    public partial interface IPersonService : IService<Person>
    {
		// Add extra serviceinterface methods in a partial interface
	}
}