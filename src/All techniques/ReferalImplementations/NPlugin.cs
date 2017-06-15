using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class NPlugin : IConvention 
    {
        private readonly IBeep[] _beeps;

        public NPlugin(IBeep[] beeps)
        {
            _beeps = beeps;

        }
        public string Format(int i)
        {
            foreach (var b in _beeps)
            {
                b.Beep();
            }

            return new string('%', i);
        }
    }
}
