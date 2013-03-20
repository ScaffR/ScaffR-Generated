#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class ForgotPasswordModel
    {
        [Display(Name = "Email Address"), Required, EmailTextbox]
        public string EmailAddress { get; set; }
    }
}