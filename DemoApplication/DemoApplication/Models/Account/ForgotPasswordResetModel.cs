#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Account
{
    #region

    

    #endregion

    public class ForgotPasswordResetModel
    {
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string TemporaryPassword { get; set; }

        public string LoginUrl { get; set; }
    }
}