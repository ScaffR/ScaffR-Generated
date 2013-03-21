#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Encryption
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IdentityModel;
    using System.IdentityModel.Tokens;

    #endregion

    public class MachineKeySessionSecurityTokenHandler : SessionSecurityTokenHandler
    {
        public MachineKeySessionSecurityTokenHandler()
            : base(CreateTransforms())
        { }

        public MachineKeySessionSecurityTokenHandler(TimeSpan tokenLifetime)
            : base(CreateTransforms(), tokenLifetime)
        { }

        private static ReadOnlyCollection<CookieTransform> CreateTransforms()
        {
            return new List<CookieTransform>
                {
                    new DeflateCookieTransform(),
                    new MachineKeyCookieTransform()
                }.AsReadOnly();
        }
    }
}
