using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using Newtonsoft.Json;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Events
{
    public class MoneyTransferedEventHandler : IHandleEvent<MoneyTransferedEvent>
    {
        private readonly GenericRepository<TblEvents> _eventRepository;

        public MoneyTransferedEventHandler(GenericRepository<TblEvents> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(MoneyTransferedEvent @event)
        {
            var serializedEvent = JsonConvert.SerializeObject(@event);

            _eventRepository.Create(new TblEvents { JSON = serializedEvent});
        }
    }
}
