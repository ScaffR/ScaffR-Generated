
namespace DemoApplication.Core.Interfaces.Membership
{
    public interface IPasswordPolicy
    {
        string PolicyMessage { get; }
        bool ValidatePassword(string password);
    }
}
