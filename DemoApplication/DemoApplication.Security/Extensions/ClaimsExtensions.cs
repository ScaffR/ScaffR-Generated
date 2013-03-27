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
namespace DemoApplication.Security.Extensions
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    #endregion

    public static class ClaimsExtensions
    {
        public static string GetValue(this IEnumerable<Claim> claims, string type)
        {
            if (claims != null)
            {
                var claim = claims.SingleOrDefault(x => x.Type == type);
                if (claim != null) return claim.Value;
            }

            return null;
        }
        
        public static IEnumerable<string> GetValues(this IEnumerable<Claim> claims, string claimType)
        {
            if (claims == null) return Enumerable.Empty<string>();

            var query =
                from claim in claims
                where claim.Type == claimType
                select claim.Value;
            return query.ToArray();
        }
    }
}
