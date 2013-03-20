#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Application
{
    #region

    using System.Web;

    #endregion

    /// <summary>
    /// Fired when a new user visits the application Web site.
    /// </summary>
    public partial class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Session_s the start.
        /// </summary>
        protected void Session_Start()
        {            
        }
    }
}