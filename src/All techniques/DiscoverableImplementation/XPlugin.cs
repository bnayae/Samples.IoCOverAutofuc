using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class XPlugin : IConvention
    {
        public XPlugin()
        {

        }
        public string Format(int i) => new string('*', i);
    }
}
