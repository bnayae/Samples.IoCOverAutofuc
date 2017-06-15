using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class YPlugin : IConvention
    {
        private readonly IBar _bar;

        public YPlugin(IBar bar)
        {
            _bar = bar;
        }

        public string Format(int i)
        {
            string data = _bar.Read();
            var format = new string('#', i);
            return $"{format} {data} {format}";
        }
    }
}
