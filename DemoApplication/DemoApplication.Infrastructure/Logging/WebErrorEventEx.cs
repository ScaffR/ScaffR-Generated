using System;
using System.Web.Management;

namespace DemoApplication.Infrastructure.Logging
{
    public class WebErrorEventEx : WebErrorEvent
    {
        public WebErrorEventEx(Exception ex, object eventSource)
            : base(ex.Message, eventSource, ExceptionCodes.GetExceptionCode(ex), ex)
        {
            
        }
    }
}