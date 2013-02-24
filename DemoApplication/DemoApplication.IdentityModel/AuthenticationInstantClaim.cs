/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel
{
    using System;
    using System.Security.Claims;
    using System.Xml;
    using Constants;

    /// <summary>
    /// Helper class to create an authentication instant claim
    /// </summary>
    public static class AuthenticationInstantClaim
    {
        /// <summary>
        /// Returns an authentication instant claim for the current date/time
        /// </summary>
        /// <value>authentication instant claim.</value>
        public static Claim Now
        {
            get
            {
                return new Claim(ClaimTypes.AuthenticationInstant, XmlConvert.ToString(DateTime.UtcNow, DateTimeFormats.Generated), ClaimValueTypes.DateTime);
            }
        }
    }
}
