using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bnaya.Samples
{
    public class BeepIt:  IBeep
    {
        public void Beep() => Console.Beep(1600, 800);

    }
}
