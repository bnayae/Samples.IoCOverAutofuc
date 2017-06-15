using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contracts;

namespace Infra
{
    // need Autofac dependency
    public class InfraModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // create the type instead of letting Autofac to do it for you
            builder.RegisterInstance(new ConfigMode())
                   .As<IConfigMode>(); // singleton by definition

            builder.RegisterType<Logger>()
                .As<ILogger>()
                .As<ILoggerEvents>()
               .SingleInstance();
        }
    }
}
