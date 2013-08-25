#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Interfaces.Data
{
    #region

    

    #endregion

    public partial interface IUserRepository : IRepository<User>
    {		
		// Add extra datainterface methods in a partial interface
	}
}
