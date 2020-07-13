using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.UserDomain.Events
{
    public class UserLogoutEvent : DomainEventBase
    {
        public int UserId { get; set; }
    }
}
