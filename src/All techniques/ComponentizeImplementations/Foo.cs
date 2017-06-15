using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bnaya.Samples
{
    public class Foo: IFoo, IBeep
    {
        private readonly IBar _bar;
        private readonly IColor _color;
        private readonly IBeep[] _beeps;

        public Foo(IBar bar, IColor color, IEnumerable<IBeep> beeps)
        {
            _bar = bar;
            _color = color;
            _beeps = beeps.ToArray();
        }

        public void Beep() => Console.Beep(1000, 1500);

        public void Write()
        {
            string data = _bar.Read();
            _color.Write(ConsoleColor.Yellow,
                             () => Console.WriteLine($"Foo => {data}"));
            foreach (var b in _beeps)
            {
                b.Beep();
            }
        }
    }
}
