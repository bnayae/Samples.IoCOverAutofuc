using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace WinEventLogProvider
{
    // The logs will be visible at the Windows's Event Viewer -> Windows Logs -> Applicative
    public class WinEventLoggerProvider : ILoggerProvider
    {
        public const string SOURCE_CONFIG_KEY = "Logger.WinEvent.Setting";
        private readonly string _source;

        // Constructor injection (no need for AutoFac reference)
        public WinEventLoggerProvider(IConfiguration repository)
        {
            var setting = repository.Get<WinEventSetting>(SOURCE_CONFIG_KEY);
            _source = setting.Source;
        }

        public void Log(LogMessage log)
        {
            EventLogEntryType severity;
            switch (log.Level)
            {
                case SeverityLevel.Debug:
                case SeverityLevel.Info:
                    severity = EventLogEntryType.Information;
                    break;
                case SeverityLevel.Warn:
                    severity = EventLogEntryType.Warning;
                    break;
                case SeverityLevel.Error:
                    severity = EventLogEntryType.Error;
                    break;
                default:
                    throw new NotImplementedException();
            }
            EventLog.WriteEntry(_source, log.Text, severity);
        }
    }
}
