/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Http.Cors
{
    public interface IHttpResponseWrapper
    {
        void AddHeader(string name, string value);
    }
}
