using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Utils.Enums;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Events
{
    public class MoneyTransferedEvent : DomainEventBase
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransferMoneyStatus Status { get; set; }

        public MoneyTransferedEvent(int accountId, decimal amount, TransferMoneyStatus status)
        {
            AccountId = accountId;
            Amount = amount;
            Status = status;
        }

    }
}
