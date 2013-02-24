namespace DemoApplication.Infrastructure.Configuration
{
    using System.Configuration;

    public partial class InfrastructureSection : ConfigurationSection
    {
        public static InfrastructureSection GetConfig()
        {
            return (InfrastructureSection)ConfigurationManager.GetSection("DemoApplication/DemoApplication.Infrastructure");
        }
    }
}
