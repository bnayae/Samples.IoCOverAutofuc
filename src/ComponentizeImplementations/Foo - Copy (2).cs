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

        public Foo(IBar bar)
        {
            _bar = bar;
        }

        public void Beep() => Console.Beep(1000, 1500);

        public void Write()
        {
            string data = _bar.Read();
            _color.Write(ConsoleColor.Yellow,
                             () => Console.WriteLine($"Foo => {data}"));
        }
    }
}
