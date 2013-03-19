#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Authentication
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Mvc;
    using Core.Interfaces.Service;

    #endregion

    public partial class AuthenticationTransformer : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
            {
                return incomingPrincipal;
            }

            return Transform(incomingPrincipal);
        }

        ClaimsPrincipal Transform(ClaimsPrincipal incomingPrincipal)
        {
            var nameClaim = incomingPrincipal.Identities.First().FindFirst(ClaimTypes.Name);

            var userService = DependencyResolver.Current.GetService<IUserService>();

            var user = userService.GetByUsername(nameClaim.Value);
            
           
            //// get roles...
            //var claims = new List<Claim>();

            //foreach (var claim in user.Claims)
            //{
            //    claims.Add(new Claim(claim.Type, claim.Value));
            //}

            //incomingPrincipal.Identities.FirstOrDefault().AddClaims(claims);
           
            return incomingPrincipal;
        }
    }
}