using Bank.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Bank.Tests.Application
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
                var vinodPredefinedAccounts = context.Logins.FirstOrDefault(x => x.Login == "satya".ToUpper()).PreDefinedAccounts;
                var vinodValidationPredefinedAccount = vinodPredefinedAccounts.Where(x => x.Login.Login == "robot".ToUpper()).Any();

                Assert.IsTrue(vinodValidationPredefinedAccount);

            }

        }
    }
}
