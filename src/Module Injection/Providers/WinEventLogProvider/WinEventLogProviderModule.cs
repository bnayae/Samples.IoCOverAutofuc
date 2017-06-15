using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WinEventLogProvider
{
    // need Autofac dependency
    public class WinEventLogProviderModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WinEventLoggerProvider>()
                    // implicitly registering of all interface of the  type
                    .AsImplementedInterfaces()
                   .SingleInstance();
        }
    }
}
