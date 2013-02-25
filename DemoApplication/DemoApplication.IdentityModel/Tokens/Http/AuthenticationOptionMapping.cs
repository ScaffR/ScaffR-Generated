/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Tokens.Http
{
    using System.IdentityModel.Tokens;

    public class AuthenticationOptionMapping
    {
        public AuthenticationOptions Options { get; set; }
        public SecurityTokenHandlerCollection TokenHandler { get; set; }
    }
}
