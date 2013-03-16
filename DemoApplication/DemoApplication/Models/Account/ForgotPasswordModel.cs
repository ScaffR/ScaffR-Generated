namespace DemoApplication.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    public partial class ForgotPasswordModel
    {
        [Display(Name = "Email Address"), Required, EmailTextbox]
        public string EmailAddress { get; set; }
    }
}