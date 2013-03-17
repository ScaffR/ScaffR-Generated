namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;

    #endregion

    public partial class CoreSection : ConfigurationSection
    {
        private static CoreSection _section; 
        public static CoreSection Instance
        {
            get
            {
                return (_section ?? (_section = (CoreSection) ConfigurationManager.GetSection("DemoApplication")));
            }
        }
    }
}
