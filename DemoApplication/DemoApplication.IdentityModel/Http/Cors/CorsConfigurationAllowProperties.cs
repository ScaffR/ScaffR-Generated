/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Http.Cors
{
    using System.Collections.Generic;
    using System.Linq;

    public class CorsConfigurationAllowProperties
    {
        public CorsConfigurationAllowProperties()
        {
            Methods = Enumerable.Empty<string>();
            RequestHeaders = Enumerable.Empty<string>();
            ResponseHeaders = Enumerable.Empty<string>();
        }

        public bool AllowAnyOrigin { get; set; }

        public IEnumerable<string> Methods { get; set; }
        public bool AllowAllMethods { get; set; }

        public IEnumerable<string> RequestHeaders { get; set; }
        public bool AllowAllRequestedHeaders { get; set; }

        public IEnumerable<string> ResponseHeaders { get; set; }
        public bool AllowCookies { get; set; }

        public int? CacheDuration { get; set; }
    }
}
