using Bank.Application.AccountDomain.Commands;
using Bank.Application.BusinessRules;
using Bank.Application.Utils;
using Bank.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CQRS.BankApp.Tests.Core
{
    [TestClass]
    public class BusinessRulesTests
    {
        private BankAccounts _bankAccountFrom;
        private MoneyTransferCommand _moneyTransferCommand;

        [TestInitialize]
        public void Init()
        {
            _bankAccountFrom = new BankAccounts
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
