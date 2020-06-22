using Autofac;
using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Services;
using CQRS.BankApp.Persistance;
using CQRS.BankApp.Persistance.Repositories;

namespace CQRS.BankApp.Core
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


            //Persistance assembly
            var assembly = typeof(MockDataContext).Assembly;

            builder.RegisterGeneric(typeof(GenericRepository<>)).AsSelf();

        }
    }
}
