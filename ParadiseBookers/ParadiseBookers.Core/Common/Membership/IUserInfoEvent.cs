namespace ParadiseBookers.Core.Common.Membership
{
    public interface IUserInfoEvent
    {
        string Tenant { get; }
        string Username { get; }
    }
}
