#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security
{
    #region

    using Configuration;

    #endregion

    public partial class Security
    {

        private readonly SecurityElement _config;

        public Security(SecurityElement config)
        {
            _config = config;
        }

        public SecurityLevel SecurityLevel
        {
            get { return _config.SecurityLevel; }
        }
    }
}