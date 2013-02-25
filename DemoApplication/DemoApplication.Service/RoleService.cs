namespace DemoApplication.Service
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Interfaces.Service;
    using DemoApplication.Core.Model;

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