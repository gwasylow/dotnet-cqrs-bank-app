using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.AccountDomain.Commands;
using CQRS.BankApp.Core.Domains.AccountDomain.Events;
using CQRS.BankApp.Core.Domains.BusinessRules;
using CQRS.BankApp.Core.Utils.Enums;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;

namespace CQRS.BankApp.Core.Domains.AccountDomain.CommandHandlers
{
    public class MoneyTransferCommandHandler : IHandleCommand<MoneyTransferCommand>
    {
        private readonly GenericRepository<TblBankAccounts> _bankAccountRepository;
        private readonly IEventsBus _eventBus;

        public MoneyTransferCommandHandler(GenericRepository<TblBankAccounts> bankAccountRepository,IEventsBus eventBus)
        {
            _bankAccountRepository = bankAccountRepository;
            _eventBus = eventBus;
        }
        public void Handle(MoneyTransferCommand command)
        {
            var bankAccountFrom = _bankAccountRepository.GetById(command.SenderAccountId);

            BusinessRuleChecker.Handle(new IsTransferedAmountOfMoneyAvailableBusinessRule(bankAccountFrom, command));

            bankAccountFrom.Balance -= command.Amount;

            _bankAccountRepository.Update(bankAccountFrom);
            _eventBus.Publish(new MoneyTransferedEvent(command.SenderAccountId,command.Amount,TransferMoneyStatus.SEND));

            var bankAccountTo = _bankAccountRepository.GetById(command.ReceiverAccountId);
            bankAccountTo.Balance += command.Amount;

            _bankAccountRepository.Update(bankAccountTo);
            _eventBus.Publish(new MoneyTransferedEvent(command.ReceiverAccountId, command.Amount, TransferMoneyStatus.RECEIVE));
        }
    }
}
