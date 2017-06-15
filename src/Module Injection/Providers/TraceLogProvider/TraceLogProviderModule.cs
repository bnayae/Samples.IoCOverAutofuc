using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contracts;

namespace TraceLogProvider
{
    // need Autofac dependency
    public class TraceLogProviderModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TraceLoggerProvider>()
                    // implicitly registering of all interface of the  type
                    .As<ILoggerProvider>()
                   .SingleInstance();
        }
    }
}
