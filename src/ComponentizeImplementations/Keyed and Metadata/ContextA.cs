using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bnaya.Samples
{
    public class ContextA : IContext
    {
        public void Log()
        {
            Console.WriteLine("Context A");
        }
    }
}
