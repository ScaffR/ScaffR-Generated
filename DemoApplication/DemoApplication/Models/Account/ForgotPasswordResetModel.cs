namespace DemoApplication.Models.Account
{
    #region

    

    #endregion

    public class ForgotPasswordResetModel
    {
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string TemporaryPassword { get; set; }

        public string LoginUrl { get; set; }
    }
}