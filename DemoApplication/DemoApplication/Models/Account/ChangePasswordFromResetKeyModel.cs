namespace DemoApplication.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ChangePasswordFromResetKeyModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Password confirmation must match password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Key { get; set; }
    }
}