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
            // this log provider don't have dependency over the setting
            builder.RegisterType<TraceLoggerProvider>()
                    .Keyed<ILoggerProvider>("Primal") 
                    .As<ILoggerProvider>()
                    .SingleInstance();
        }
    }
}
