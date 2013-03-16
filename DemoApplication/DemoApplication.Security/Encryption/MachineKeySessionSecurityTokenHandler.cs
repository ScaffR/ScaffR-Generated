namespace DemoApplication.Security.Encryption
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IdentityModel;
    using System.IdentityModel.Tokens;

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
