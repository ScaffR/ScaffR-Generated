namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class ForgotPasswordModel
    {
        [Display(Name = "Email Address"), Required, EmailTextbox]
        public string EmailAddress { get; set; }
    }
}