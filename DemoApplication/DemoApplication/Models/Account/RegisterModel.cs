namespace DemoApplication.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    public partial class RegisterModel
    {
        [Required]
        [Display(Name = "User Name", Order = 1)]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string Username { get; set; }
		
		[Required]
        [Display(Name = "First Name", Order = 1)]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name", Order = 2)]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address", Order = 3 )]
        [Textbox(TextboxSize = TextboxSize.Large)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email", Order = 4)]
        [Textbox(TextboxSize = TextboxSize.Large)]
        [Compare("Email", ErrorMessage = "The email and confirm email do not match.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Textbox(DataType.Password, TextboxSize = TextboxSize.Large)]
        [Display(Name = "Password", Order = 6)]
        public string Password { get; set; }

        [Required]
        [Textbox(DataType.Password, TextboxSize = TextboxSize.Large)]
        [Display(Name = "Confirm password", Order = 7)]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}