namespace DemoApplication.Areas.Api
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
        }
    }
}