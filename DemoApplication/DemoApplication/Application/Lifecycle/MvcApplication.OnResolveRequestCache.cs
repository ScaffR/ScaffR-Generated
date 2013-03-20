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
    /// <summary>
    /// Class MvcApplication
    /// </summary>
    public partial class MvcApplication
    {
        /// <summary>
        /// Fired when the ASP.NET page framework completes an authorization request. It allows caching modules to serve the request from the cache, thus bypassing handler execution.
        /// </summary>
        protected void Application_ResolveRequestCache()
        {            

        }
    }
}