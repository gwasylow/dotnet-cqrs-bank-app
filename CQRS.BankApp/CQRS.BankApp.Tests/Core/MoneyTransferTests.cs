using Autofac;
using CQRS.BankApp.Core;
using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.AccountDomain.Commands;
using CQRS.BankApp.Core.Domains.AccountDomain.Queries;
using CQRS.BankApp.Persistance.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CQRS.BankApp.Tests.Core
{
    [TestClass]
    public class MoneyTransferTests
    {
        private IContainer _container;
        private MoneyTransferCommand _moneyTransfer;
        private GetAccountQueryById _firstBankAccount;
        private GetAccountQueryById _secondBankAccount;

        [TestInitialize]
        public void Init()
        {

            var assembly = typeof(ICoreAssemblyMarker).Assembly;
            var builder = new ContainerBuilder();

            //Initialize all autofac modules in assembly
            builder.RegisterAssemblyModules(assembly);
            _container = builder.Build();

            _moneyTransfer = new MoneyTransferCommand
            {
                Amount = 100,
                ReceiverAccountId = 1,
                SenderAccountId = 2
            };

            _firstBankAccount = new GetAccountQueryById
            {
                Id = 1
            };

            _secondBankAccount = new GetAccountQueryById
            {
                Id = 2
            };
        }

        [TestMethod]
        public void CheckTransferBetweenTwoAccounts()
        {
            var firstBankAccountBalanceBeforeTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, TblBankAccounts>(_firstBankAccount).Balance;
            var secondBankAccountBalanceBeforeTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, TblBankAccounts>(_secondBankAccount).Balance;

            _container.Resolve<ICommandsBus>().Send(_moneyTransfer);

            var firstBankAccountBalanceAfterTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, TblBankAccounts>(_firstBankAccount).Balance;
            var secondBankAccountBalanceAfterTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, TblBankAccounts>(_secondBankAccount).Balance;

            Assert.AreEqual(firstBankAccountBalanceBeforeTransfer, firstBankAccountBalanceAfterTransfer - _moneyTransfer.Amount);
            Assert.AreEqual(secondBankAccountBalanceBeforeTransfer, secondBankAccountBalanceAfterTransfer + _moneyTransfer.Amount);

        }
    }
}
