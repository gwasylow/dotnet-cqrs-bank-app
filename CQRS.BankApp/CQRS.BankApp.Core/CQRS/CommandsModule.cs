using Autofac;
using System;

namespace CQRS.BankApp.Core.CQRS
{
    /// <summary>
    /// Register all command handlers to autofac container.
    /// </summary>
    internal class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IHandleCommand>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, IHandleCommand>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IHandleCommand<>).MakeGenericType(t);
                    return (IHandleCommand)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<CommandsBus>()
                .AsImplementedInterfaces();
        }
    }
}
