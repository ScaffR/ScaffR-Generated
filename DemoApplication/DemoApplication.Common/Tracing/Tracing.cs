﻿#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Common
// Author	: Rod Johnson
// Created	: 03-23-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Common.Tracing
{
    #region

    using System;
    using System.Diagnostics;

    #endregion

    public static class Tracing
    {
        [DebuggerStepThrough]
        public static void Start(string message)
        {
            TraceEvent(TraceEventType.Start, message, false);
        }

        [DebuggerStepThrough]
        public static void Stop(string message)
        {
            TraceEvent(TraceEventType.Stop, message, false);
        }

        [DebuggerStepThrough]
        public static void Information(string message)
        {
            TraceEvent(TraceEventType.Information, message, false);
        }

        [DebuggerStepThrough]
        public static void Warning(string message)
        {
            TraceEvent(TraceEventType.Warning, message, false);
        }

        [DebuggerStepThrough]
        public static void Error(string message)
        {
            TraceEvent(TraceEventType.Error, message, false);
        }

        [DebuggerStepThrough]
        public static void Verbose(string message)
        {
            TraceEvent(TraceEventType.Verbose, message, false);
        }

        [DebuggerStepThrough]
        public static void TraceEvent(TraceEventType type, string message, bool suppressTraceService)
        {
            TraceSource ts = new TraceSource("DemoApplication");

            if (Trace.CorrelationManager.ActivityId == Guid.Empty)
            {
                if (type != TraceEventType.Verbose)
                {
                    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                }
            }

            ts.TraceEvent(type, 0, message);
        }
    }
}
