using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    // No need for AutoFac reference

    public interface ILoggerProvider
    {
        void Log(LogMessage mesage);
    }
}
