#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Authentication
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Services;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Security;
    using Common.Tracing;
    using Core.Interfaces.Service;
    using Core.Model;
    using Extensions;
    using Infrastructure.Extensions;

    #endregion

    public class ClaimsAuthenticationService : IAuthenticationService
    {
        public virtual void SignIn(User user, bool isPersistant = false)
        {
            Tracing.Information(String.Format("[ClaimsBasedAuthenticationService.Signin] called: {0}", user.Username));

            if (String.IsNullOrWhiteSpace(user.Username)) throw new ArgumentException("username");

            // gather claims
            var claims = new List<Claim>();
            foreach (UserClaim uc in user.Claims)
                claims.Add(new Claim(uc.Type, uc.Value));

            if (!String.IsNullOrWhiteSpace(user.Email))
            {
                claims.Insert(0, new Claim(ClaimTypes.Email, user.Email));
            }
            claims.Insert(0, new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password));
            claims.Insert(0, new Claim(ClaimTypes.AuthenticationInstant, DateTime.UtcNow.ToString("s")));
            claims.Insert(0, new Claim(ClaimTypes.Name, user.Username));
            claims.Insert(0, new Claim(ClaimTypes.NameIdentifier, user.Username));

            // create principal/identity
            var id = new ClaimsIdentity(claims, "Forms");
            var cp = new ClaimsPrincipal(id);

            // claims transform
            cp = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager.Authenticate(String.Empty, cp);

            // issue cookie
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            if (sam == null)
                throw new Exception("SessionAuthenticationModule is not configured and it needs to be.");

            var token = new SessionSecurityToken(cp, isPersistant ?  FormsAuthentication.Timeout : TimeSpan.FromMinutes(SessionHelpers.GetSessionTimeoutInMinutes))
                {
                    IsPersistent = isPersistant
                };
            sam.WriteSessionTokenToCookie(token);

            Tracing.Verbose(String.Format("[ClaimsBasedAuthenticationService.Signin] cookie issued: {0}", claims.GetValue(ClaimTypes.NameIdentifier)));
        }

        public virtual void SignOut()
        {
            Tracing.Information(String.Format("[ClaimsBasedAuthenticationService.SignOut] called: {0}", ClaimsPrincipal.Current.Claims.GetValue(ClaimTypes.NameIdentifier)));

            // clear cookie
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            if (sam == null)
            {
                Tracing.Verbose("[ClaimsBasedAuthenticationService.Signout] SessionAuthenticationModule is not configured");
                throw new Exception("SessionAuthenticationModule is not configured and it needs to be.");
            }

            sam.SignOut();            
        }
    }
}