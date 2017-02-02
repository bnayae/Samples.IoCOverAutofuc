using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class ComponentizeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Foo>().As<IFoo>();
            builder.RegisterType<BeepIt>().As<IBeep>();
        }
    }
}
