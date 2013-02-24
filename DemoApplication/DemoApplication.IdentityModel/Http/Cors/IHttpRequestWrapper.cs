/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Http.Cors
{
    using System.Collections.Generic;

    public interface IHttpRequestWrapper
    {
        string Resource { get; }
        IDictionary<string, object> Properties { get; }
        string Method { get; }
        string GetHeader(string name);
    }
}
