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

    public partial class ForgotPasswordModel
    {
        [Display(Name = "Email Address"), Required, EmailTextbox]
        public string EmailAddress { get; set; }
    }
}