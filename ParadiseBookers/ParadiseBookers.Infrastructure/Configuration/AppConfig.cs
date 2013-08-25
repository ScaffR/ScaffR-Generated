#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Configuration;

namespace ParadiseBookers.Infrastructure.Configuration
{
    #region

    

    #endregion

    public partial class AppConfig : ConfigurationSection
    {
        private static AppConfig _section; 
        public static AppConfig Instance
        {
            get
            {
                return (_section ?? (_section = (AppConfig) ConfigurationManager.GetSection("ParadiseBookers")));
            }
        }
    }
}
