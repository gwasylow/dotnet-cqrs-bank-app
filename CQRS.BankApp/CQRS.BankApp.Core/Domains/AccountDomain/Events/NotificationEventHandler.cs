using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Events
{
    public class NotificationEventHandler : IHandleEvent<MoneyTransferedEvent>
    {
        private readonly GenericRepository<TblNotifications> _notificationRepository;
        private readonly GenericRepository<TblLogins> _loginRepository;

        public NotificationEventHandler(GenericRepository<TblNotifications> notificationRepository, GenericRepository<TblLogins> loginRepository)
        {
            _notificationRepository = notificationRepository;
            _loginRepository = loginRepository;
        }
        public void Handle(MoneyTransferedEvent @event)
        {
            var notification = new TblNotifications {
                IsDisplayed = false,
                Login = _loginRepository.GetById(@event.AccountId),
                Message = string.Format($"{@event.Amount} transfered : {@event.OccurredOn}.")
            };
            _notificationRepository.Create(notification);
        }
    }
}
