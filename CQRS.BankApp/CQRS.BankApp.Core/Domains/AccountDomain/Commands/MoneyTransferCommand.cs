using CQRS.BankApp.Core.CQRS;
using System.ComponentModel.DataAnnotations;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Commands
{
    public class MoneyTransferCommand : ICommand
    {
        [Required]
        public int ReceiverAccountId { get; set; }

        [Required]
        public int SenderAccountId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}