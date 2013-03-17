namespace DemoApplication.Core.Interfaces.Service
{
    #region

    using Model;

    #endregion

    public partial interface IUserService
    {
        User GetByUsername(string userName);
    }
}