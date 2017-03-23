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

            //var f = container.Resolve<IFoo>();
            //var f1 = container.ResolveKeyed<IFoo>("Special");
            //f.Write();

            //var cs = container.Resolve<IEnumerable<IConvention>>();
            //var cs1 = container.Resolve<IEnumerable<IConvention>>();
            //foreach (var c in cs)
            //{
            //    string d = c.Format(10);
            //    Console.WriteLine($"{d.GetHashCode()}: {d}");
            //}
            //Console.WriteLine();
            //Console.WriteLine("Hash code should be the same for singleton");
            //cs = container.Resolve<IEnumerable<IConvention>>();
            //cs = container.Resolve<IEnumerable<IConvention>>();
            //foreach (var c in cs)
            //{
            //    string d = c.Format(10);
            //    Console.WriteLine($"{d.GetHashCode()}: {d}");
            //}

            IAlternateExecuter executer = container.Resolve<IAlternateExecuter>();
            for (int i = 0; i < 5; i++)
            {
                executer.Run();
            }
            Console.ReadKey();
        }

        private static IContainer Initialize()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterInstance(new ZPlugin())
                   .As<IBeep>()
                   .As<IConvention>()
                   .SingleInstance();
            builder.RegisterType<Bar>()
                    .AsImplementedInterfaces()
                    .SingleInstance();
            builder.RegisterType<CheapExecution>()
                    .Keyed<IAlternate>(InstanceTypes.Cheap)
                    .SingleInstance();
            //builder.RegisterType<NPlugin>()
            //        .AsImplementedInterfaces();
            builder.Register(c =>
            {
                var beeps = c.Resolve<IEnumerable<IBeep>>();
                return new NPlugin(beeps.ToArray());
            })
            .As<IConvention>()
            .SingleInstance();

            // Scan an assembly for components
            var path = Path.GetFullPath("DiscoverableImplementation.dll");
            var asmDiscover = Assembly.LoadFile(path);
            builder.RegisterAssemblyTypes(asmDiscover)
                   .Where(t => t.Name.EndsWith("Plugin") ||
                               t.GetInterface(typeof(IColor).FullName) != null)
                   .AsImplementedInterfaces()
                   .SingleInstance();

            //foreach (var file in Directory.GetFiles("Plugins", "Enghouse.*.dll")
            //{

            //}
            path = Path.GetFullPath("ComponentizeImplementations.dll");
            var asmComp = Assembly.LoadFile(path);
            builder.RegisterAssemblyModules(asmComp);

            path = Path.GetFullPath("ComponentizeAutofacAware.dll");
            asmComp = Assembly.LoadFile(path);
            builder.RegisterAssemblyModules(asmComp);

            //asmComp = typeof(Bar).Assembly;
            //builder.RegisterAssemblyModules(asmComp);

            var container = builder.Build();
            return container;
        }
    }
}
