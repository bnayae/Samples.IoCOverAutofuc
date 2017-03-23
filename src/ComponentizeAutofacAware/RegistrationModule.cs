using Autofac;
using Autofac.Features.AttributeFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Samples
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlternateExecuter>()
                    .As<IAlternateExecuter>()
                    .WithAttributeFiltering()
                    .SingleInstance();
        }
    }
}
