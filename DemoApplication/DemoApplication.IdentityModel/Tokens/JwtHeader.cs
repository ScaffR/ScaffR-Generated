/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Tokens
{
    using System.IdentityModel.Tokens;
    using Constants;

    public class JwtHeader
    {
        public string SignatureAlgorithm { get; set; }
        public string Type { get; set; }
        
        public SigningCredentials SigningCredentials { get; set; }

        public JwtHeader()
        {
            Type = JwtConstants.JWT;
        }
    }
}
