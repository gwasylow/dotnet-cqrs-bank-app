using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using Newtonsoft.Json;
using System;

namespace CQRS.BankApp.Core.Domains.UserDomain.Events
{
    public class UserLogoutEventHandler : IHandleEvent<UserLogoutEvent>
    {
        private readonly GenericRepository<TblEvents> _eventRepository;

        public UserLogoutEventHandler(GenericRepository<TblEvents> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(UserLogoutEvent @event)
        {
            var serializedEvent = JsonConvert.SerializeObject(@event);

            _eventRepository.Create(new TblEvents { JSON = serializedEvent });
        }
    }
}
