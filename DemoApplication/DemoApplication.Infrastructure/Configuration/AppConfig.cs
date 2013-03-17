namespace DemoApplication.Infrastructure.Configuration
{
    #region

    using System.Configuration;

    #endregion

    public partial class AppConfig : ConfigurationSection
    {
        private static AppConfig _section; 
        public static AppConfig Instance
        {
            get
            {
                return (_section ?? (_section = (AppConfig) ConfigurationManager.GetSection("DemoApplication")));
            }
        }
    }
}
