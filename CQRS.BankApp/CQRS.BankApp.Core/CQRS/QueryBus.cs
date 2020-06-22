using System;

namespace CQRS.BankApp.Core.CQRS
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type,Type, IHandleQuery> _handlersFactory;
        public QueryBus(Func<Type, Type, IHandleQuery> handlersFactory)

        {
            _handlersFactory = handlersFactory;
        }

        public TResult Send<TQuery,TResult>(TQuery command) where TQuery : IQuery
        {
            var handler = (IHandleQuery<TQuery,TResult>)_handlersFactory(typeof(TQuery),typeof(TResult));
            return handler.Handle(command);
        }
    }
}