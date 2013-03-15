namespace DemoApplication.Core.Interfaces.Service
{
    public interface IAuthenticationService
    {
        void SignIn(string username);
        void SignOut();
    }
}
