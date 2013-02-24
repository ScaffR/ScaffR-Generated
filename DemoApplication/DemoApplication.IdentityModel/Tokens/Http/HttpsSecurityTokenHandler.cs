/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Tokens.Http
{
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;

    class HttpsSecurityTokenHandler : X509SecurityTokenHandler
    {
        public HttpsSecurityTokenHandler()
            : base(X509CertificateValidator.None)
        {
            Configuration = new SecurityTokenHandlerConfiguration
            {
                IssuerNameRegistry = new HttpsIssuerNameRegistry()
            };
        }
    }
}
