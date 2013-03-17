#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Authentication
{
    #region

    using System;
    using System.IdentityModel.Services;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.Security.Claims;
    using Core.Extensions;
    using Core.Interfaces.Service;
    using Infrastructure.Tracing;

    #endregion

    public class ClaimsBasedAuthenticationService : IAuthenticationService
    {
        const int DefaultTokenLifetime_InHours = 10;

        IUserService userService;

        public ClaimsBasedAuthenticationService(IUserService userService)
        {
            this.userService = userService;
        }

        public virtual void SignIn(string username)
        {
            Tracing.Information(String.Format("[ClaimsBasedAuthenticationService.Signin] called: {0}", username));

            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentException("username");

            // find user
            var account = this.userService.GetByUsername(username);
            if (account == null) throw new ArgumentException("Invalid username");

            // gather claims
            var claims =
                (from uc in account.Claims
                 select new Claim(uc.Type, uc.Value)).ToList();

            if (!String.IsNullOrWhiteSpace(account.Email))
            {
                claims.Insert(0, new Claim(ClaimTypes.Email, account.Email));
            }
            claims.Insert(0, new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password));
            claims.Insert(0, new Claim(ClaimTypes.AuthenticationInstant, DateTime.UtcNow.ToString("s")));
            claims.Insert(0, new Claim(ClaimTypes.Name, account.Username));
            claims.Insert(0, new Claim(ClaimTypes.NameIdentifier, account.Username));

            // create principal/identity
            var id = new ClaimsIdentity(claims, "Forms");
            var cp = new ClaimsPrincipal(id);

            // claims transform
            cp = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager.Authenticate(String.Empty, cp);

            // issue cookie
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            if (sam == null)
            {
                Tracing.Verbose("[ClaimsBasedAuthenticationService.Signin] SessionAuthenticationModule is not configured");
                throw new Exception("SessionAuthenticationModule is not configured and it needs to be.");
            }

            var token = new SessionSecurityToken(cp, TimeSpan.FromHours(DefaultTokenLifetime_InHours));
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