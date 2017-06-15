using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace TraceLogProvider
{
    public class TraceLoggerProvider : ILoggerProvider
    {
        public void Log(LogMessage log)
        {
            Trace.WriteLine(log.Text, log.Level.ToString());
        }
    }
}
