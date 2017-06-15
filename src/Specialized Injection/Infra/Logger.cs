using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Infra
{
    public class Logger : ILogger, ILoggerEvents
    {
        private readonly ILoggerProvider[] _providers;

        // Constructor injection (no need for AutoFac reference)
        // at the hosting level each dependencies can be register
        // separately (no needs to register collection of provider)
        public Logger(ILoggerProvider[] providers)
        {
            _providers = providers;
        }

        public event Action<LogMessage> LogNotification;

        public void Log(SeverityLevel level, object text)
        {
            var message = new LogMessage(level, text?.ToString());
            foreach (var provider in _providers)
            {
                provider.Log(message);
            }
            LogNotification?.Invoke(message);
        }
    }
}
