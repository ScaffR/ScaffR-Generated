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
