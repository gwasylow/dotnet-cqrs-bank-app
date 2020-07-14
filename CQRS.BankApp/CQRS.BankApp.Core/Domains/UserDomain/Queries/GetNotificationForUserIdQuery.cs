using CQRS.BankApp.Core.CQRS;
using System.ComponentModel.DataAnnotations;

namespace CQRS.BankApp.Core.Domains.UserDomain.Queries
{
    public class GetNotificationForUserIdQuery : IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
