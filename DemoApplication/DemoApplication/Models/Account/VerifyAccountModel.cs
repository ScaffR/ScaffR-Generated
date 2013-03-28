#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Account
{
    public class VerifyAccountModel
    {
        public string EmailAddress { get; set; }
        public string VerificationUrl { get; set; }
    }
}