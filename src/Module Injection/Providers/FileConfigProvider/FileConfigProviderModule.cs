using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contracts;

namespace FileConfigProvider
{
    // need Autofac dependency
    public class FileConfigProviderModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                // use to inject environmental dependencies 
                // like the configuration folder
                var mode = c.Resolve<IConfigMode>();
                return new FileSettingProvider("Config", mode);
            })
            .As<IConfiguration>()
            .SingleInstance();
        }
    }
}
