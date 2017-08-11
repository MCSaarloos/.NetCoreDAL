using Autofac;
using NetCoreDAL.DataAccess.Impl;
using NetCoreDAL.DataAccess.Infrastructure.Interfaces;
using System.Reflection;

namespace NetCoreDAL.Composition.Modules
{
    internal class NetCoreDalModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var businessAssemblyName = new AssemblyName("netcoredal.business");
            builder.RegisterAssemblyTypes(Assembly.Load(businessAssemblyName))
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();

            var dataAccessAssemblyName = new AssemblyName("netcoredal.dataaccess");
            builder.RegisterAssemblyTypes(Assembly.Load(dataAccessAssemblyName))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }
    }
}
