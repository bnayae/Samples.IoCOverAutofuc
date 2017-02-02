using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class ZPlugin : IConvention, IBeep
    {
        public void Beep()
        {
            Console.Beep();
        }

        public string Format(int i) => new string('%', i);
    }
}
