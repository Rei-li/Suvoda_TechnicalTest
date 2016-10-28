using Autofac;
using Suvoda.TechnicalTest.BLL.Services.Depots;
using Suvoda.TechnicalTest.BLL.Services.DrugTypes;
using Suvoda.TechnicalTest.BLL.Services.DrugUnits;
using Suvoda.TechnicalTest.DAL.Repositories.Depots;

namespace Suvoda.TechnicalTest.BLL.AutofacConfig
{
    class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepotsService>().As<IDepotsService>().InstancePerLifetimeScope();
            builder.RegisterType<DrugTypesService>().As<IDrugTypesService>().InstancePerLifetimeScope();
            builder.RegisterType<DrugUnitsService>().As<IDrugUnitsService>().InstancePerLifetimeScope();
           
        }
    }
}
