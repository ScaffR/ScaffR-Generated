namespace DemoApplication.Security.Authorization
{
    #region

    using System.Security.Claims;

    #endregion

    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            return true;
        }        

    }
}
