using Autofac;
using Bank.Application.Services;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.IoC
{
    /// <summary>
    /// Register Core components to autofac container.
    /// </summary>
    internal class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<JWTTokenService>().AsSelf();

            //Infrastructure assembly
            var assembly = typeof(MockDataContext).Assembly;

            builder.RegisterGeneric(typeof(GenericRepository<>)).SingleInstance().AsSelf();
        }
    }
}
