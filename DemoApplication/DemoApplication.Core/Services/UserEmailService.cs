namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

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