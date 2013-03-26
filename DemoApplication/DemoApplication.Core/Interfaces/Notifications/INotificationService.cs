using DemoApplication.Core.Model;

namespace DemoApplication.Core.Interfaces.Notifications
{
    public interface INotificationService
    {
        void SendAccountCreate(User user);
        void SendAccountVerified(User user);
        void SendResetPassword(User user);
        void SendPasswordChangeNotice(User user);
        void SendAccountNameReminder(User user);
        void SendAccountDelete(User user);
        void SendChangeEmailRequestNotice(User user, string newEmail);
        void SendEmailChangedNotice(User user, string oldEmail);
    }
}