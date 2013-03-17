namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

    public partial class RoleService : BaseService<Role>, IRoleService
    {
		protected new IRoleRepository Repository;				
		
		public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
			:base(unitOfWork)
		{
		    base.Repository = Repository = roleRepository;
		}		
	}
}