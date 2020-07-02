namespace CQRS.BankApp.Core.CQRS
{
    public interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
