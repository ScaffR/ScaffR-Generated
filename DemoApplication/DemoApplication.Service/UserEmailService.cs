namespace DemoApplication.Service
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Interfaces.Service;
    using DemoApplication.Core.Model;

    public partial class UserEmailService : BaseService<UserEmail>, IUserEmailService
    {
		protected new IUserEmailRepository Repository;				
		
		public UserEmailService(IUnitOfWork unitOfWork, IUserEmailRepository useremailRepository)
			:base(unitOfWork)
		{
		    base.Repository = Repository = useremailRepository;
		}		
	}
}