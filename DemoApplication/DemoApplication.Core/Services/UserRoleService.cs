namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

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