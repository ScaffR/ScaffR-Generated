/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Authorization.Todo
{
    using System.Security.Claims;
    using System.Web.Http.Controllers;

    public class HttpAuthorizationContext : AuthorizationContext
    {
        private HttpActionContext _context;

        protected HttpActionContext ActionContext
        {
            get { return _context; }
        }

        public HttpAuthorizationContext(HttpActionContext context)
            : base(ClaimsPrincipal.Current,
                   context.ControllerContext.ControllerDescriptor.ControllerName,
                   context.Request.Method.Method)
        {
            _context = context;
        }
    }
}
