using Autofac;
using Bank.Application.AccountDomain.Commands;
using Bank.Application.CQRS.Interface;
using Bank.Application.IoC;
using Bank.Application.UsersAccount.Queries;
using Bank.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests.Application
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

            var assembly = typeof(IDependentAssemblyMarker).Assembly;
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
                AccountId = 1
            };

            _secondBankAccount = new GetAccountQueryById
            {
                AccountId = 2
            };
        }

        [TestMethod]
        public void CheckTransferBetweenTwoAccounts()
        {
            var firstBankAccountBalanceBeforeTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, BankAccounts>(_firstBankAccount).Balance;
            var secondBankAccountBalanceBeforeTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, BankAccounts>(_secondBankAccount).Balance;

            _container.Resolve<ICommandsBus>().Send(_moneyTransfer);

            var firstBankAccountBalanceAfterTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, BankAccounts>(_firstBankAccount).Balance;
            var secondBankAccountBalanceAfterTransfer = _container.Resolve<IQueryBus>().Send<GetAccountQueryById, BankAccounts>(_secondBankAccount).Balance;

            Assert.AreEqual(firstBankAccountBalanceBeforeTransfer, firstBankAccountBalanceAfterTransfer - _moneyTransfer.Amount);
            Assert.AreEqual(secondBankAccountBalanceBeforeTransfer, secondBankAccountBalanceAfterTransfer + _moneyTransfer.Amount);

        }
    }
}
