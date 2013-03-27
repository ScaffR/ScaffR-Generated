#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-18-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

    public partial class UserClaimService : BaseService<UserClaim>, IUserClaimService
    {
        protected new IUserClaimRepository Repository;

        public UserClaimService(IUnitOfWork unitOfWork, IUserClaimRepository userRepository)
			:base(unitOfWork)
		{
		    base.Repository = Repository = userRepository;
		}		
	}
}