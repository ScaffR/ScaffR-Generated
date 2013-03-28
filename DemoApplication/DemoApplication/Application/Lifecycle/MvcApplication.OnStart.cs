#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Application
{
    #region

    using System.Web.Mvc;
    using ModelBinders;

    #endregion

    /// <summary>
    /// Class MvcApplication
    /// </summary>
    public partial class MvcApplication
	{
        /// <summary>
        /// Fired when the first instance of the HttpApplication class is created. It allows you to create objects that are accessible by all HttpApplication instances.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Startup.AppStartup.Routes();

            //Add my MVC Provider
            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProviderMvc());
        }
	}
}