namespace CQRS.BankApp.Core.CQRS
{
    internal interface IHandleCommand
    {

    }
    internal interface IHandleCommand<TCommand> : IHandleCommand
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
