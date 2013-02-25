/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Web
{
    using System.IdentityModel.Services;
    using System.Web;

    class ServiceAwareWSFederationAuthenticationModule : WSFederationAuthenticationModule
    {
        public const string DefaultLabel = "ServiceAwareWSFederationAuthenticationModule:IsService";

        protected override void OnAuthorizationFailed(AuthorizationFailedEventArgs e)
        {
            base.OnAuthorizationFailed(e);

            var isService = HttpContext.Current.Items[DefaultLabel];

            if (isService != null)
            {
                e.RedirectToIdentityProvider = false;
            }
        }
    }
}
