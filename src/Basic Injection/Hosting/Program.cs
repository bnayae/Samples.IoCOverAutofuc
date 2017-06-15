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

            builder.RegisterType<Logger>()
                    // explicit registering multiple interface of the type
                    // you may choose to do it implicitly with: 
                    //  .AsImplementedInterfaces()
                    .As<ILogger>()
                    .As<ILoggerEvents>()
                   // prefer singleton registration 
                   // (register Factory instead of letting 
                   // the IoC create transient instance of dependencies)
                   .SingleInstance();

            builder.Register(c =>
            {
                // use to inject environmental dependencies 
                // like the configuration folder
                var mode = c.Resolve<IConfigMode>();
                return new FileSettingProvider("Config", mode);
            })
            .As<IConfiguration>()
            .SingleInstance();

            // create the type instead of letting Autofac to do it for you
            builder.RegisterInstance(new ConfigMode())
                   .As<IConfigMode>(); // singleton by definition

            builder.RegisterType<TraceLoggerProvider>()
                    // implicitly registering of all interface of the  type
                    .As<ILoggerProvider>()
                   .SingleInstance();
            builder.RegisterType<WinEventLoggerProvider>()
                    // implicitly registering of all interface of the  type
                    .AsImplementedInterfaces()
                   .SingleInstance();

            builder.RegisterType<TheLogic>()
                    .As<ILogic>()
                    .SingleInstance();

            var container = builder.Build();
            // get instance of ILogic with all of it dependencies
            var logic = container.Resolve<ILogic>();
            return logic;
        }
    }
}
