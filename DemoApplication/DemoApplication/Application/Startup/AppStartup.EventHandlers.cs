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
#region

using DemoApplication.Application.Startup;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "EventHandlers")]

namespace DemoApplication.Application.Startup
{
    /// <summary>
    /// Class AppStartup
    /// </summary>
    public partial class AppStartup
    {
        public static void EventHandlers()
        {
        }
    }
}