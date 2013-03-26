namespace DemoApplication.Core.Services
{
    using Interfaces.Notifications;

    public class NopNotificationService : INotificationService
    {
        public void SendAccountCreate(Model.User user)
        {
            
        }

        public void SendAccountVerified(Model.User user)
        {
            
        }

        public void SendResetPassword(Model.User user)
        {
            
        }

        public void SendPasswordChangeNotice(Model.User user)
        {
            
        }

        public void SendAccountNameReminder(Model.User user)
        {
            
        }

        public void SendAccountDelete(Model.User user)
        {
            
        }

        public void SendChangeEmailRequestNotice(Model.User user, string newEmail)
        {
            
        }

        public void SendEmailChangedNotice(Model.User user, string oldEmail)
        {
            
        }
    }
}
