using DemoApplication.Application.Bootstrappers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Bootstrapper), "EventHandlers")]

namespace DemoApplication.Application.Bootstrappers
{
    public partial class Bootstrapper
    {
        public static void EventHandlers()
        {
        }
    }
}