
namespace DemoApplication.Core.Common.Membership.PasswordPolicies
{
    using Interfaces.Membership;

    public class NopPasswordPolicy : IPasswordPolicy
    {
        public string PolicyMessage
        {
            get { return "There is no password policy."; }
        }

        public bool ValidatePassword(string password)
        {
            return true;
        }
    }
}
