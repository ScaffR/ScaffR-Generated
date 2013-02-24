namespace DemoApplication.Service
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Interfaces.Service;
    using DemoApplication.Core.Model;

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