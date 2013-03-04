namespace DemoApplication.Application
{
    using System.Web.Mvc;
    using Bootstrappers;
    using ModelBinders;

    public partial class MvcApplication
	{
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Bootstrapper.Routes();

            //Add my MVC Provider
            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProviderMvc());
        }
	}
}