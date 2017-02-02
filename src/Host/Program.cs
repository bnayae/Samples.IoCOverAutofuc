using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = Initialize();

            var f = container.Resolve<IFoo>();
            f.Write();

            var cs = container.Resolve<IEnumerable<IConvention>>();
            foreach (var c in cs)
            {
                string d = c.Format(10);
                Console.WriteLine(d);
            }

            Console.ReadKey();
        }

        private static IContainer Initialize()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterInstance(new ZPlugin())
                   .As<IBeep>()
                   .As<IConvention>();
            builder.RegisterType<Bar>()
                    .AsImplementedInterfaces();
            builder.Register(c =>
            {
                var beeps = c.Resolve<IEnumerable<IBeep>>();
                return new NPlugin(beeps.ToArray());
            })
            .As<IConvention>();

            // Scan an assembly for components
            var path = Path.GetFullPath("DiscoverableImplementation.dll");
            var asmDiscover = Assembly.LoadFile(path);
            builder.RegisterAssemblyTypes(asmDiscover)
                   .Where(t => t.Name.EndsWith("Plugin") ||
                               t.GetInterface(typeof(IColor).FullName) != null)
                   .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(asmDiscover)
                   .Where(t => t.Name.EndsWith("Plugin") ||
                               t.GetInterface(typeof(IColor).FullName) != null)
                   .AsImplementedInterfaces();

            path = Path.GetFullPath("ComponentizeImplementations.dll");
            var asmComp = Assembly.LoadFile(path);
            builder.RegisterAssemblyModules(asmComp);

            var container = builder.Build();
            return container;
        }
    }
}
