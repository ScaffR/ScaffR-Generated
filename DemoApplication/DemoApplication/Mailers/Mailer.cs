#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Mailers
{
    #region

    using Mvc.Mailer;

    #endregion

    public partial class Mailer : MailerBase
    {
        public Mailer()
        {
            MasterName = "_Layout";
        }       
    }
}