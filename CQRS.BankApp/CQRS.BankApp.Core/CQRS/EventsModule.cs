using Autofac;
using System;

namespace CQRS.BankApp.Core.CQRS
{
    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
               .Where(x => x.IsAssignableTo<IHandleEvent>())
               .AsImplementedInterfaces();

            builder.Register<Func<Type, IHandleEvent>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IHandleEvent<>).MakeGenericType(t);
                    return (IHandleEvent)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<EventsBus>()
                .AsImplementedInterfaces();
        }
    }
}
