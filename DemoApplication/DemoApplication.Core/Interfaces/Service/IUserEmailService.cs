#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Service
{
    #region

    using Model;

    #endregion

    public partial interface IUserEmailService : IService<UserEmail>
    {
		// Add extra serviceinterface methods in a partial interface
	}
}