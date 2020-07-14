using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

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

            builder.Register<Func<Type, IEnumerable<IHandleEvent>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var tmpList = new List<IHandleEvent>();

                    var handlerType = typeof(IHandleEvent<>).MakeGenericType(t);

                    var reslovedType = ctx.Resolve(handlerType);
                    
                    if (reslovedType is IEnumerable<IHandleEvent>)
                    {
                        return (IEnumerable<IHandleEvent>)reslovedType;
                    }
                    else
                    {
                        tmpList.Add((IHandleEvent)reslovedType);
                    }

                    return tmpList.AsEnumerable();
                };
            });

            builder.RegisterType<EventsBus>()
                .AsImplementedInterfaces();
        }
    }
}
