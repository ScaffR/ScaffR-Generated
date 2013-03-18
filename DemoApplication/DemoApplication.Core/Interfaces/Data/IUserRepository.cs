#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using Model;

    #endregion

    public partial interface IUserRepository : IRepository<User>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
