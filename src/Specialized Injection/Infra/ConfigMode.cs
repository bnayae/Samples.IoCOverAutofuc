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
        public ConfigModes Mode
        {
            get
            {
                if (Debugger.IsAttached)
                    return ConfigModes.Debug;
                else
                    return ConfigModes.Prod;
             }  
        }
    }
}
