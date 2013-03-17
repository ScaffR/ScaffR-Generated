namespace DemoApplication.Application
{
    #region

    using System.Web.Mvc;
    using ModelBinders;
    using Startup;

    #endregion

    public partial class MvcApplication
	{
        /// <summary>
        /// Fired when the first instance of the HttpApplication class is created. It allows you to create objects that are accessible by all HttpApplication instances.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AppStartup.Routes();

            //Add my MVC Provider
            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProviderMvc());
        }
	}
}