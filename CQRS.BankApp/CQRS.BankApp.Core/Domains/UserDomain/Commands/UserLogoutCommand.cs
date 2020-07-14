using CQRS.BankApp.Core.CQRS;
using System.ComponentModel.DataAnnotations;

namespace CQRS.BankApp.Core.Domains.UserDomain.Commands
{
    public class UserLogoutCommand : ICommand
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Key { get; set; }
    }
}
