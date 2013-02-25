/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Http.Cors.IIS
{
    using System.Web;

    class HttpContextResponse : IHttpResponseWrapper
    {
        HttpResponseBase response;
        public HttpContextResponse(HttpResponseBase response)
        {
            this.response = response;
        }

        public void AddHeader(string name, string value)
        {
            response.AddHeader(name, value);
        }
    }
}
