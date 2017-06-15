using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contracts;

namespace WinEventLogProvider
{
    // need Autofac dependency
    public class WinEventLogProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WinEventLoggerProvider>()
                    .As<ILoggerProvider>()
                    .SingleInstance();
        }
    }
}
