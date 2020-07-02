using CQRS.BankApp.Core.Domains.AccountDomain.Commands;
using CQRS.BankApp.Persistance.Entities;

namespace CQRS.BankApp.Core.Domains.BusinessRules
{
    public class IsTransferedAmountOfMoneyAvailableBusinessRule : IBusinessRule
    {
        private TblBankAccounts _bankAccountFrom;
        private MoneyTransferCommand _moneyTransferCommand;

        public string ErrorMessage => "Not sufficient amount of money on account.";

        public IsTransferedAmountOfMoneyAvailableBusinessRule(TblBankAccounts bankAccountFrom, MoneyTransferCommand command)
        {
            this._bankAccountFrom = bankAccountFrom;
            this._moneyTransferCommand = command;
        }

        public bool IsValid()
        {
            return (_bankAccountFrom.Balance > 0 && _bankAccountFrom.Balance > _moneyTransferCommand.Amount);
        }
    }
}
