using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Suvoda.TechnicalTest.Mappings;

namespace Suvoda.TechnicalTest.AutofacConfig
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DtoModelMapper>().As<IDtoModelMapper>().InstancePerLifetimeScope();
        }
    }
}