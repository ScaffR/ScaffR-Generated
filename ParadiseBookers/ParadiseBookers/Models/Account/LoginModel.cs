#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using ParadiseBookers.Metadata.Attributes;

namespace ParadiseBookers.Models.Account
{
    #region

    

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