namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class ForgotPasswordResetModel
    {
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string TemporaryPassword { get; set; }

        public string LoginUrl { get; set; }
    }
}