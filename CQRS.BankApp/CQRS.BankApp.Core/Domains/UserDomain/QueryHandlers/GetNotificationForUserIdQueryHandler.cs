using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.BankApp.Core.Domains.UserDomain.QueryHandlers
{
    public class GetNotificationForUserIdQueryHandler : IHandleQuery<GetNotificationForUserIdQuery, IEnumerable<NotificationModel>>
    {
        private readonly GenericRepository<TblNotifications> _notificationRepository;

        public GetNotificationForUserIdQueryHandler(GenericRepository<TblNotifications> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public IEnumerable<NotificationModel> Handle(GetNotificationForUserIdQuery query)
        {
            var notifications = _notificationRepository.GetAll().Where(x=>x.Login.Id == query.UserId && x.IsDisplayed == false);

            //TODO: Set IsDisplayed to false
            //_notificationRepository.Update()

            return notifications.Select(x => new NotificationModel
            {
                Message = x.Message
            });
        }
    }
}
