namespace DemoApplication.Core.Configuration
{
    using System.Configuration;

    public partial class CoreSection : ConfigurationSection
    {
        public static CoreSection GetConfig()
        {
            return (CoreSection)ConfigurationManager.GetSection("TaskForceManager/TaskForceManager.Core");
        }       
    }
}
