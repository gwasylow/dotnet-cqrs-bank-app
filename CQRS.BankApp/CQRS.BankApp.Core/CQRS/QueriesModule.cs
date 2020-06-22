using Autofac;
using System;

namespace CQRS.BankApp.Core.CQRS
{
    /// <summary>
    /// Register all queries handlers to autofac container.
    /// </summary>
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IHandleQuery>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type,Type, IHandleQuery>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return (typeIn,typeOut) =>
                {
                    var handlerType = typeof(IHandleQuery<,>)
                        .MakeGenericType(new Type[] { typeIn,typeOut });
                    return (IHandleQuery)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<QueryBus>()
                .AsImplementedInterfaces();
        }
    }
}
