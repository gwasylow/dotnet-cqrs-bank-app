using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.UserDomain.Commands
{
    public class UserLogoutCommand : ICommand
    {
        public int UserId { get; set; }
        public string Key { get; set; }
    }
}
