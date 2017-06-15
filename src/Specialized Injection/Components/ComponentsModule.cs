using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contracts;

namespace Components
{
    // need Autofac dependency
    public class ComponentsModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TheLogic>()
                    .As<ILogic>()
                    .SingleInstance();
        }
    }
}
