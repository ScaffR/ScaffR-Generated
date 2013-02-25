/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Http.Cors
{
    public class CorsConfigurationEntry : CorsConfigurationAllowProperties
    {
        public bool AllResources { get; set; }
        public string Resource { get; set; }

        public string Origin { get; set; }
    }
}
