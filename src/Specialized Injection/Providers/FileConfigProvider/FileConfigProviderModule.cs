using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Indexed;
using Contracts;

namespace FileConfigProvider
{
    // need Autofac dependency
    public class FileConfigProviderModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // this registration has bug 
            //builder.RegisterType<FileSettingProvider>()
            //        .As<IConfiguration>()
            //        .SingleInstance();

            builder.Register(C =>
                    {
                        var cnfMode = C.Resolve<IConfigMode>();
                        var log = C.ResolveKeyed<ILoggerProvider>("Primal");
                        var selector = C.Resolve<IIndex<ConfigModes, IFolderSelector>>();
                        var instance = new FileSettingProvider(cnfMode, log, selector);
                        return instance;
                    })
                    .As<IConfiguration>()
                    .SingleInstance();
        }
    }
}
