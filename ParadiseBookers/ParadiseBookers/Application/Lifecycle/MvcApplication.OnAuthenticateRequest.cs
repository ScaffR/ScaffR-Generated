#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace ParadiseBookers.Application
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