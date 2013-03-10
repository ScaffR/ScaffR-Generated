namespace DemoApplication.Application
{
    using System;

    public partial class MvcApplication
	{
        /// <summary>
        /// Fired when an unhandled exception is encountered within the application.
        /// </summary>
        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();

            // process exception

            Server.ClearError();
        }
	}
}