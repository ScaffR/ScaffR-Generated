namespace DemoApplication.Core.Interfaces.Service
{
    using Model;

    public partial interface IUserService
    {
        User GetByUsername(string userName);
    }
}