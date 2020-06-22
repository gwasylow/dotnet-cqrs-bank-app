using System;

namespace CQRS.BankApp.Core.CQRS
{
    internal class CommandsBus : ICommandsBus
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;
        public CommandsBus(Func<Type, IHandleCommand> handlersFactory)

        {
            _handlersFactory = handlersFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (IHandleCommand<TCommand>)_handlersFactory(typeof(TCommand));
            handler.Handle(command);
        }
    }
}