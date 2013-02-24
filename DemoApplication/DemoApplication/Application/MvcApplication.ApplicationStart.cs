namespace DemoApplication.Application
{
    using System.Web.Mvc;
    using Bootstrappers;

    public partial class MvcApplication
	{
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Bootstrapper.Routes();
        }
	}
}