namespace DemoApplication.Models
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public partial class ForgotPasswordModel
    {
        [Display(Name = "Email Address"), Required, Email]
        public string EmailAddress { get; set; }
    }
}