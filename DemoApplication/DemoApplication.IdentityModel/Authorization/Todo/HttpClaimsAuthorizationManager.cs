/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Authorization.Todo
{
    using System.IdentityModel.Services;
    using System.Security.Claims;
    using System.Web.Http.Controllers;

    public class HttpClaimsAuthorizationManager : IAuthorizationManager
    {
        ClaimsAuthorizationManager _authZ;

        public HttpClaimsAuthorizationManager()
        {
            _authZ = FederatedAuthentication.FederationConfiguration
                                            .IdentityConfiguration
                                            .ClaimsAuthorizationManager;
        }

        public HttpClaimsAuthorizationManager(ClaimsAuthorizationManager authorizationManager)
        {
            _authZ = authorizationManager;
        }

        public bool CheckAccess(HttpActionContext context)
        {
            var authZcontext = new HttpAuthorizationContext(context);
            return _authZ.CheckAccess(authZcontext);
        }
    }
}
