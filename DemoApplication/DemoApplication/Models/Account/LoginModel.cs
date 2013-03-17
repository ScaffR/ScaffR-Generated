namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        [Textbox(TextboxSize = TextboxSize.Medium)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [PasswordTextbox(TextboxSize = TextboxSize.Medium)]
        public string Password { get; set; }
        
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [ScaffoldColumn(false)]
        public string ReturnUrl { get; set; }
    }
}