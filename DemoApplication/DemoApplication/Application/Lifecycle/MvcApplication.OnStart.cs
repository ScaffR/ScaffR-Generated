#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Application
{
    #region

    using System.Web.Mvc;
    using Extensions.ErrorHandlingHelpers;
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

            // Wrap the controller factory so that we handle 404s
            ControllerBuilder.Current.SetControllerFactory(
                new ControllerFactoryWrapper(
                    ControllerBuilder.Current.GetControllerFactory()
                )
            );

            // Add my MVC Provider
            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProviderMvc());
        }
    }
}