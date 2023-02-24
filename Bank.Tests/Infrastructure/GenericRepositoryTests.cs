using Bank.Core.Entities;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace Bank.Tests.Application
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private BankAccounts _bankAccount;
        private GenericRepository<BankAccounts> _bankAccountsRepository;


        [TestInitialize]
        public void Init()
        {
            _bankAccountsRepository = new GenericRepository<BankAccounts>();

            using (var context = new MockDataContext())
            {
                _bankAccount = new BankAccounts
                {
                    Id = 1,
                    AccountNo = "SBI012121020101",
                    Balance = 900,
                    Login = context.Logins.FirstOrDefault(x => x.Login == "satya".ToUpper())
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
