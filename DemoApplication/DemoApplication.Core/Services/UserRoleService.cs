#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
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