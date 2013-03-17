namespace DemoApplication.Application
{
    #region

    using System.Web;

    #endregion

    /// <summary>
    /// Fired when a new user visits the application Web site.
    /// </summary>
    public partial class MvcApplication : HttpApplication
    {
        protected void Session_Start()
        {            
        }
    }
}