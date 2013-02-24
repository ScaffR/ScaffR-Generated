using DemoApplication.Bootstrappers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Bootstrapper), "EventHandlers")]

namespace DemoApplication.Bootstrappers
{
    public partial class Bootstrapper
    {
        public static void EventHandlers()
        {
        }
    }
}