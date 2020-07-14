using CQRS.BankApp.Core.CQRS;
using System.ComponentModel.DataAnnotations;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Queries
{
    public class GetAccountForUserIdQuery: IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
