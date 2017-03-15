using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bnaya.Samples
{
    public class SpecialFoo : IFoo
    {

        public void Write()
        {
            Console.WriteLine("I'm Special");
        }
    }
}
