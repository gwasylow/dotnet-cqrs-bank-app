using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.UserDomain.Queries
{
    public class LoginQuery : IQuery
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
