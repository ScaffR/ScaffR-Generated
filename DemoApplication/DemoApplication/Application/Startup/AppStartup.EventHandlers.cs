using DemoApplication.Application.Startup;

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "EventHandlers")]

namespace DemoApplication.Application.Startup
{
    public partial class AppStartup
    {
        public static void EventHandlers()
        {
        }
    }
}