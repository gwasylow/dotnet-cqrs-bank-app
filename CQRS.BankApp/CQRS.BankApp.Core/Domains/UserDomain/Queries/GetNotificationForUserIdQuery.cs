using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.UserDomain.Queries
{
    public class GetNotificationForUserIdQuery : IQuery
    {
        public int UserId { get; set; }
    }
}
