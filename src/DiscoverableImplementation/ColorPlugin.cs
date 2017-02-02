using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class ColorPlugin : IColor
    {
        public void Write(ConsoleColor c, Action action)
        {
            Console.ForegroundColor = c;
            action();
            Console.ResetColor();
        }
    }
}
