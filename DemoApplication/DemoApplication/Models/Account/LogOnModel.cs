namespace DemoApplication.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    public partial class LogOnModel
    {
        [Required]
        [Display(Name = "Username")]
        [Textbox(TextboxSize = TextboxSize.Medium)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordTextbox(TextboxSize = TextboxSize.Medium)]
        public string Password { get; set; }
        
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}