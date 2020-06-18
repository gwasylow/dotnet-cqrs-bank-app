using CQRS.BankApp.Persistance;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.BankApp.Tests.Persistance
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private TblBankAccounts _bankAccount;
        private GenericRepository<TblBankAccounts> _bankAccountsRepository;


        [TestInitialize]
        public void Init()
        {
            _bankAccountsRepository = new GenericRepository<TblBankAccounts>();

            using (var context = new MockDataContext())
            {
                _bankAccount = new TblBankAccounts
                {
                    Id = 1,
                    AccountNo = "EU 0000 1234 2222 4444 11",
                    Balance = 900,
                    Login = context.Logins.FirstOrDefault(x => x.Login == "grazynka".ToUpper())
                };
            }
           
        }
        [TestMethod]
        public void CreateShouldAddNewEntity()
        {
            var bankAccountCounter = _bankAccountsRepository.GetAll().ToList().Count;
            _bankAccountsRepository.Create(_bankAccount);
            var actualBankAccountCounter = _bankAccountsRepository.GetAll().ToList().Count;

            var expectedBankAccountCounter = bankAccountCounter + 1;


            Assert.AreEqual(expectedBankAccountCounter, actualBankAccountCounter);

        }

        [TestMethod]
        public void UpdateShouldModifyEntity()
        {
            var entity = _bankAccountsRepository.GetById(1);
            var oldBalance = entity.Balance;
            entity.Balance += 100;
            
            _bankAccountsRepository.Update(entity);


            var updatedEntity = _bankAccountsRepository.GetById(1);

            var actualBalance = updatedEntity.Balance;
            var expectedBalance = oldBalance + 100;

            Assert.AreEqual(actualBalance, expectedBalance);
        }


    }
}
