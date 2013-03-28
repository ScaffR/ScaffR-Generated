#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-26-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    #endregion

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