namespace DemoApplication.Mailers
{
    using Mvc.Mailer;

    public partial class Mailer : MailerBase
    {
        public Mailer()
        {
            MasterName = "_Layout";
        }       
    }
}