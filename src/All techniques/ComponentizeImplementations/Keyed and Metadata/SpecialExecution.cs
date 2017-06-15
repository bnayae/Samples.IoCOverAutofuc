using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bnaya.Samples
{
    public class SpecialExecution : IAlternate
    {
        public void Execute()
        {
            Console.WriteLine("This is special");
        }
    }
}
