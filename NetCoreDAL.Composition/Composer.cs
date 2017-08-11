using Autofac;
using NetCoreDAL.Composition.Modules;

namespace NetCoreDAL.Composition
{
    public static class Composer
    {
        public static void Compose(this ContainerBuilder builder)
        {
            builder.RegisterModule<NetCoreDalModule>();
        }
    }
}
