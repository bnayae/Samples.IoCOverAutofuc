using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Infra
{
    public class ConfigMode : IConfigMode
    {
        public bool IsDebug => Debugger.IsAttached;
    }
}
