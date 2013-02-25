/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Tokens
{
    using System.IdentityModel.Tokens;

    public class WebTokenSecurityKeyClause : SecurityKeyIdentifierClause
    {
        public string Issuer { get; set; }

        public WebTokenSecurityKeyClause(string issuer)
            : base("WebToken")
        {
            Issuer = issuer;
        }
    }
}
