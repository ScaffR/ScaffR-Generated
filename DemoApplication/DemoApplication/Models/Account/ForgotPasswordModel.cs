namespace DemoApplication.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    public partial class ForgotPasswordModel
    {
        [Display(Name = "Email Address"), Required, Email]
        public string EmailAddress { get; set; }
    }
}