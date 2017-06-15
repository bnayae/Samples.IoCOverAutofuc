using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Components;
using Contracts;
using FileConfigProvider;
using Infra;
using TraceLogProvider;
using WinEventLogProvider;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogic logic = InitializeIoC();
            double result = logic.Calc(10);
            Console.WriteLine($"Result = {result}");
            Console.ReadKey(true);
        }

        private static ILogic InitializeIoC()
        {
            // Using Autofac to composite dependencies
            var builder = new ContainerBuilder();

            // Different options for registrations:

            builder.RegisterModule<FileConfigProviderModule>();
            builder.RegisterModule<TraceLogProviderModule>();
            builder.RegisterModule<WinEventLogProviderModule>();
            builder.RegisterModule<ComponentsModule>();
            builder.RegisterModule<InfraModule>();

            var container = builder.Build();
            // get instance of ILogic with all of it dependencies
            var logic = container.Resolve<ILogic>();
            return logic;
        }
    }
}
