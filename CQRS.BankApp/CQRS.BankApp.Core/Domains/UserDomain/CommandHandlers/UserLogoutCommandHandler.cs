using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain.Commands;
using CQRS.BankApp.Core.Domains.UserDomain.Events;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using System.Linq;

namespace CQRS.BankApp.Core.Domains.UserDomain.CommandHandlers
{
    public class UserLogoutCommandHandler : IHandleCommand<UserLogoutCommand>
    {
        private readonly IEventsBus _eventBus;
        private readonly GenericRepository<TblInvalidKeys> _invalidKeysRepository;

        public UserLogoutCommandHandler(IEventsBus eventBus, GenericRepository<TblInvalidKeys> invalidKeysRepository)
        {
            _eventBus = eventBus;
            _invalidKeysRepository = invalidKeysRepository;
        }

        public void Handle(UserLogoutCommand command)
        {
            var invalidKey = new TblInvalidKeys
            {
                Key = command.Key,
                UserId = command.UserId,
                Id = _invalidKeysRepository.GetAll().Count() + 1
            };

            _invalidKeysRepository.Create(invalidKey);

            _eventBus.Publish(new UserLogoutEvent { UserId = command.UserId });
        }
    }
}
