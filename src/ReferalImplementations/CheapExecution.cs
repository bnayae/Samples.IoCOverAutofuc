using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class CheapExecution : IAlternate
    {
        public void Execute()
        {
            Console.WriteLine("Very cheap choice");
        }
    }
}
