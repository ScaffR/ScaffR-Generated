namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

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