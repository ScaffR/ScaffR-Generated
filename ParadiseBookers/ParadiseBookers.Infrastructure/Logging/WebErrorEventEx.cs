using System;
using System.Web.Management;

namespace ParadiseBookers.Infrastructure.Logging
{
    public class WebErrorEventEx : WebErrorEvent
    {
        public WebErrorEventEx(Exception ex, object eventSource)
            : base(ex.Message, eventSource, ExceptionCodes.GetExceptionCode(ex), ex)
        {
            
        }
    }
}