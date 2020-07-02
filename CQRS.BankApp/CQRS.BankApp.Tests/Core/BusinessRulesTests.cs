using CQRS.BankApp.Core.Domains.AccountDomain.Commands;
using CQRS.BankApp.Core.Domains.BusinessRules;
using CQRS.BankApp.Core.Utils;
using CQRS.BankApp.Persistance.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Tests.Core
{
    [TestClass]
    public class BusinessRulesTests
    {
        private TblBankAccounts _bankAccountFrom;
        private MoneyTransferCommand _moneyTransferCommand;

        [TestInitialize]
        public void Init()
        {
            _bankAccountFrom = new TblBankAccounts
            {
                Balance = 100
            };

            _moneyTransferCommand = new MoneyTransferCommand
            {
                Amount = 120
            };
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void TransferedAmountShouldntBeLessThanActualBalance()
        {
            BusinessRuleChecker.Handle(new IsTransferedAmountOfMoneyAvailableBusinessRule(_bankAccountFrom, _moneyTransferCommand));
        }
    }
}
