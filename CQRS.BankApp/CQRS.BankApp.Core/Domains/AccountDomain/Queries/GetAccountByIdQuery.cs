using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Queries
{
    public class GetAccountQueryById : IQuery
    {
        public int Id { get; set; }
    }
}
