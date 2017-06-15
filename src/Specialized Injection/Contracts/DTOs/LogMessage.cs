using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class LogMessage
    {
        public LogMessage(SeverityLevel level, string text)
        {
            Level = level;
            Text = text;
        }
        public SeverityLevel Level { get; }
        public string Text { get; }
    }
}
