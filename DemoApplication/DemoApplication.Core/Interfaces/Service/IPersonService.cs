namespace DemoApplication.Core.Interfaces.Service
{
    #region

    using Model;

    #endregion

    public partial interface IPersonService : IService<Person>
    {
		// Add extra serviceinterface methods in a partial interface
	}
}