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