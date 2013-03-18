#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Mailers
{
    #region

    using System.Net.Mail;
    using Models.Account;

    #endregion

    public partial class Mailer
    {
		public virtual MailMessage ForgotPassword(ForgotPasswordResetModel model)
        {
            var mailMessage = new MailMessage { Subject = "We found your lost password" };

            mailMessage.To.Add(model.EmailAddress);
		    ViewBag.Data = model;
            PopulateBody(mailMessage, viewName: "ForgotPassword");

            return mailMessage;
        }
    }
}