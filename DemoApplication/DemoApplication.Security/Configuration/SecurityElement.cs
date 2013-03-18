#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Configuration
{
    #region

    using System.Configuration;

    #endregion

    public partial class SecurityElement : ConfigurationElement
    {
        [ConfigurationProperty("securityLevel", IsRequired = true)]
        public SecurityLevel SecurityLevel
        {
            get { return (SecurityLevel)base["securityLevel"]; }
            set { base["securityLevel"] = value; }
        }
    }
}
