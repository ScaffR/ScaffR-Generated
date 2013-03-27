#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class RegisterModel
    {
        [Required]
        [Display(Name = "User Name")]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string Username { get; set; }
		
		[Required]
        [Display(Name = "First Name")]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailTextbox(TextboxSize = TextboxSize.Large)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Email")]
        [EmailTextbox(TextboxSize = TextboxSize.Large)]
        [EqualTo("Email", ErrorMessage = "The email and confirm email do not match.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Textbox(DataType.Password, TextboxSize = TextboxSize.Large)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Textbox(DataType.Password, TextboxSize = TextboxSize.Large)]
        [Display(Name = "Confirm password")]
        [EqualTo("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Phone Number")]
        [PhoneNumberTextbox]
        public string PhoneNumber { get; set; }
    }
}