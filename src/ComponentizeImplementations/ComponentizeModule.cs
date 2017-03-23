using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class ComponentizeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Foo>().As<IFoo>()
                   .SingleInstance();
            builder.RegisterType<SpecialFoo>()
                    .Keyed<IFoo>("Special")
                   .SingleInstance();
            builder.RegisterType<BeepIt>().As<IBeep>()
                   .SingleInstance();
            builder.RegisterType<BalancedExecution>()
                    .Keyed<IAlternate>(InstanceTypes.Balanced)
                    .SingleInstance();
            builder.RegisterType<FastExecution>()
                    .Keyed<IAlternate>(InstanceTypes.Fast)
                    .SingleInstance();
            builder.RegisterType<SpecialExecution>()
                    .Keyed<IAlternate>("Special")
                    .SingleInstance();
            builder.RegisterType<ContextNon>()
                    .As<IContext>()
                    .As<IContextPlus>()
                    .SingleInstance();
            builder.RegisterType<ContextA>()
                    .As<IContext>()
                    .WithMetadata("Category", "A")
                    .WithMetadata("Importance", "High")
                    .SingleInstance();
            builder.RegisterType<ContextB>()
                    .As<IContext>()
                    .WithMetadata("Category", "B")
                    .SingleInstance();

            builder.RegisterType<ContextC>()
                    .As<IContext>()
                    .As<IContextPlus>()
                    .WithMetadata<ContextMeta>(_ => { })
                    .SingleInstance();

            builder.RegisterType<ContextD>()
                    .As<IContext>()
                    .As<IContextPlus>()
                    .WithMetadata("Importance", "High")
                    .WithMetadata<ContextMeta>(m => m.For(m1 => m1.Category, "D"))
                    .SingleInstance();
        }
    }
}
