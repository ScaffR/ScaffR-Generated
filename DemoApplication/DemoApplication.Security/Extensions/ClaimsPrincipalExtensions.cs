#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Security
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Extensions
{
    #region

    using System.Security.Claims;

    #endregion

    public static class ClaimsPrincipalExtensions
    {
        public static bool HasClaim(this ClaimsPrincipal user, string type)
        {
            if (user != null)
            {
                return user.HasClaim(x => x.Type == type);
            }
            return false;
        }
    }
}
