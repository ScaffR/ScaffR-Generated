namespace DemoApplication.Core.Interfaces.Service
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated();
        void ClearImpersonationCookie();
        void SetAuthCookie(string username, bool persisted);
        void SetImpersonationAuthCookie(int impersonatorId);
        void SignOut();
        void RedirectToLoginPage();
        string GetRedirectUrl(string username, bool createPersistentCookie);
    }
}