#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace ParadiseBookers.Models.Account
{
    public class VerifyAccountModel
    {
        public string EmailAddress { get; set; }
        public string VerificationUrl { get; set; }
    }
}