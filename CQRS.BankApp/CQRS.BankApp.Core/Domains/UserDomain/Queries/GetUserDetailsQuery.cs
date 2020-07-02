using CQRS.BankApp.Core.CQRS;
namespace CQRS.BankApp.Core.Domains.UserDomain.Queries
{
    public class GetUserDetailsQuery : IQuery
    {
        public int UserId { get; set; }
    }
}
