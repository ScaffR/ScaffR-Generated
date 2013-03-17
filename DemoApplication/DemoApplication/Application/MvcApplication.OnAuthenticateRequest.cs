#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-10-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Application
{
    /// <summary>
    /// Class MvcApplication
    /// </summary>
    public partial class MvcApplication
    {
        /// <summary>
        /// Fired when the security module has established the current user's identity as valid. At this point, the user's credentials have been validated.
        /// </summary>
        protected void Application_AuthenticateRequest()
        {            

        }
    }
}