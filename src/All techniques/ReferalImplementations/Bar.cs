using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class Bar : IBar, IConvention
    {
        public string Format(int i)
        {
            return new string('#', i);
        }

        public string Read() => "Bar";
    }
}
