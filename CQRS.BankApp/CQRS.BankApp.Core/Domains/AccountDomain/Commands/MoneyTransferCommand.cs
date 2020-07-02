using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Commands
{
    public class MoneyTransferCommand : ICommand
    {
        public int ReceiverAccountId { get; set; }
        public int SenderAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}