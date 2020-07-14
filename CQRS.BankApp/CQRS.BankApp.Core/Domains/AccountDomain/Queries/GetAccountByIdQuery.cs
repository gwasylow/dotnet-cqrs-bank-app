using CQRS.BankApp.Core.CQRS;
using System.ComponentModel.DataAnnotations;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Queries
{
    public class GetAccountQueryById : IQuery
    {
        [Required]
        public int AccountId { get; set; }
    }
}
