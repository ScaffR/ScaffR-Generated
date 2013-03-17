namespace DemoApplication.Core.Services
{
    #region

    using System;
    using System.Linq;
    using Common.Membership;
    using Model;

    #endregion

    public partial class UserService
    {
        public bool Authenticate(string username, string password, out AuthenticationStatus status, out User usr)
        {
            var user = Find(u => u.Username == username).FirstOrDefault();
            usr = null;

            if (user == null)
            {
                status = AuthenticationStatus.InvalidUsername;
                return false;
            }
                        
            if (user.Password == password)
            {
                if (user.IsLockedOut)
                {
                    status = AuthenticationStatus.UserLockedOut;
                    return false;
                }

                if (!user.IsApproved)
                {

                    status = AuthenticationStatus.UserLockedOut;
                    return false;
                }

                user.LastLoginDate = DateTime.UtcNow;
                usr = user;
                var result = SaveOrUpdate(user);

                status = AuthenticationStatus.Authenticated;
                return true;
            }

            status = AuthenticationStatus.InvalidPassword;
            return false;

            //if (user.TemporaryPassword == password)
            //{
            //    user.ResetPassword = true;
            //    user.Password = user.TemporaryPassword;
            //    SaveOrUpdate(user);
            //    return AuthenticationStatus.ResetPassword;
            //}

            //user.LastPasswordFailureDate = DateTime.UtcNow;
            //SaveOrUpdate(user);
            //return AuthenticationStatus.InvalidPassword;
        }

        public ChangePasswordStatus ChangePassword(User user, string currentPassword, string newPassword)
        {
            if (user.Password != currentPassword)
            {
                return ChangePasswordStatus.InvalidPassword;
            }
            
            try
            {
                user.ResetPassword = false;
                user.Password = newPassword;
                user.LastPasswordChangedDate = DateTime.UtcNow;
                SaveOrUpdate(user);
            }
            catch (Exception)
            {
                return ChangePasswordStatus.Failure;
            }
            
            return ChangePasswordStatus.Success;
        }

        public CreateUserStatus CreateUser(User user)
        {
            if (UserExistsAlready(user.Username))
            {
                return CreateUserStatus.DuplicateUserName;
            }

            if (Find(u => u.Email == user.Email).Any())
            {
                return CreateUserStatus.DuplicateEmail;
            }

            user.IsApproved = true;
            user.IsLockedOut = false;
            
            SaveOrUpdate(user);

            return CreateUserStatus.Success;
        }

        public ChangePasswordStatus ResetPassword(User user)
        {
            string newPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);

            return ChangePassword(user, user.Password, newPassword, true);
        }

        public bool UserExistsAlready(string userName)
        {
            User existingUser = Find(u => u.Username == userName).FirstOrDefault();

            return existingUser != null;
        }

        private static ChangePasswordStatus ChangePassword(User user, string currentPassword, string newPassword, bool resetPassword)
        {
            if (user.Password != currentPassword)
            {
                return ChangePasswordStatus.InvalidPassword;
            }

            user.ResetPassword = resetPassword;
            user.Password = newPassword;

            return ChangePasswordStatus.Success;
        }
    }
}