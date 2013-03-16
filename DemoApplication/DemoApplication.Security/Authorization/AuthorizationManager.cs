namespace DemoApplication.Security.Authorization
{
    using System.Security.Claims;

    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            return true;
        }        

    }
}
