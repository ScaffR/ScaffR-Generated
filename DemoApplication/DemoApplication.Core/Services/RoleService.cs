#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
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