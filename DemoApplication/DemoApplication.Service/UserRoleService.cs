namespace DemoApplication.Service
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Interfaces.Service;
    using DemoApplication.Core.Model;

    public partial class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
		protected new IUserRoleRepository Repository;				
		
		public UserRoleService(IUnitOfWork unitOfWork, IUserRoleRepository userroleRepository)
			:base(unitOfWork)
		{
		    base.Repository = Repository = userroleRepository;
		}		
	}
}