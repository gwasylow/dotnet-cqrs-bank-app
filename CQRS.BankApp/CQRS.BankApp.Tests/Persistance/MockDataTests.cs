using CQRS.BankApp.Persistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CQRS.BankApp.Tests.Persistance
{
    [TestClass]
    public class MockDataTests
    {
        [TestMethod]
        public void UsersFromMockContextShouldReturnNonEmptyList()
        {
            using (var context = new MockDataContext())
            {
                var list = context.Logins;
                Assert.IsTrue(list.Any());
            }
        }
        [TestMethod]
        public void AccountsFromMockContextShouldReturnNonEmptyList()
        {
            using (var context = new MockDataContext())
            {
                var list = context.BankAccounts;
                Assert.IsTrue(list.Any());
            }
        }
        [TestMethod]
        public void NotificationsFromMockContextShouldReturnEmptyList()
        {
            using (var context = new MockDataContext())
            {
                var list = context.Notifications;
                Assert.IsTrue(!list.Any());
            }
        }

        [TestMethod]
        public void UserShouldHavePreDefinedAccount()
        {
            using (var context = new MockDataContext())
            {
                var grazynkaPredefinedAccounts = context.Logins.FirstOrDefault(x => x.Login == "grazynka".ToUpper()).PreDefinedAccounts;
                var grazynkaValidationPredefinedAccount = grazynkaPredefinedAccounts.Where(x => x.Login.Login == "janusz".ToUpper()).Any();

                Assert.IsTrue(grazynkaValidationPredefinedAccount);

            }

        }
    }
}
