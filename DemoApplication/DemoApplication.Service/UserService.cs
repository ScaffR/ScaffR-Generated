namespace DemoApplication.Service
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Interfaces.Service;
    using DemoApplication.Core.Model;

    public partial class UserService : BaseService<User>, IUserService
    {
		protected new IUserRepository Repository;				
		
		public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
			:base(unitOfWork)
		{
		    base.Repository = Repository = userRepository;
		}		
	}
}