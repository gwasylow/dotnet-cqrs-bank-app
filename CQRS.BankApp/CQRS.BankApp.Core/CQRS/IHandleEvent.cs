namespace CQRS.BankApp.Core.CQRS
{
    internal interface IHandleEvent
    {
    }
    internal interface IHandleEvent<TEvent> : IHandleEvent
    where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
