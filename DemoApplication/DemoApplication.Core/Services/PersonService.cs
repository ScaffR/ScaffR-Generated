namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

    public partial class PersonService : BaseService<Person>, IPersonService
    {
		protected new IPersonRepository Repository;				
		
		public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
			:base(unitOfWork)
		{
		    base.Repository = Repository = personRepository;
		}		
	}
}