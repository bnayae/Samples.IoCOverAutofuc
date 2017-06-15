using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Infra
{
    public class DebugFolderSelector : IFolderSelector
    {
        public string Folder => "Config_Debug";
    }
}
