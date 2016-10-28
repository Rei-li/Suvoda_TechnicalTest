using Autofac;
using Suvoda.TechnicalTest.DAL.Repositories.Depots;
using Suvoda.TechnicalTest.DAL.Repositories.DrugTypes;
using Suvoda.TechnicalTest.DAL.Repositories.DrugUnits;

namespace Suvoda.TechnicalTest.DAL.AutofacConfig
{
    class RepositoryModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepotsRepository>().As<IDepotsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DrugTypesRepository>().As<IDrugTypesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DrugUnitsRepository>().As<IDrugUnitsRepository>().InstancePerLifetimeScope();
        }
    }
}
