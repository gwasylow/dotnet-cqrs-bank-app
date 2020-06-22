namespace CQRS.BankApp.Core.CQRS
{
    internal interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
