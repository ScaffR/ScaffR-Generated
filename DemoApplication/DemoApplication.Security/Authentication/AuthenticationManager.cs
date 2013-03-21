#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Security.Authentication
{
    #region

    using System.Linq;
    using System.Security.Claims;

    #endregion

    public partial class AuthenticationManager : ClaimsAuthenticationManager
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
            // todo... this is where we would put in any extra claim information
            incomingPrincipal.Identities.FirstOrDefault().AddClaim(new Claim(ClaimTypes.Role, "Admin"));
           
            return incomingPrincipal;
        }
    }
}