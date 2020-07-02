using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Queries
{
    public class GetAccountForUserIdQuery: IQuery
    {
        public int UserId { get; set; }
    }
}
