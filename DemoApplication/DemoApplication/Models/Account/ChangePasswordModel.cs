namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class ChangePasswordModel
    {
        [Required]
        [Display(Name = "Current password")]
        [PasswordTextbox]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [PasswordTextbox]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [PasswordTextbox]
        [Display(Name = "Confirm new password")] 
        [EqualTo("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}