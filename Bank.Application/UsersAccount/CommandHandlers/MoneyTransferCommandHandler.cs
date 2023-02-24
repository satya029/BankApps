using Bank.Application.AccountDomain.Commands;
using Bank.Application.BusinessRules;
using Bank.Application.CQRS.Interface;
using Bank.Application.UsersAccount.Events;
using Bank.Application.Utils.Enums;
using Bank.Core.Entities;
using Bank.Infrastructure.Repositories;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Bank.Application.AccountDomain.CommandHandlers
{
    public class MoneyTransferCommandHandler : IHandleCommand<MoneyTransferCommand>
    {
        private readonly GenericRepository<BankAccounts> _bankAccountRepository;
        private readonly IEventsBus _eventBus;

        public MoneyTransferCommandHandler(GenericRepository<BankAccounts> bankAccountRepository, IEventsBus eventBus)
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
            _eventBus.Publish(new MoneyTransferedEvent(command.SenderAccountId, command.Amount, TransferMoneyStatus.SEND));

            var bankAccountTo = _bankAccountRepository.GetById(command.ReceiverAccountId);
            bankAccountTo.Balance += command.Amount;

            _bankAccountRepository.Update(bankAccountTo);
            _eventBus.Publish(new MoneyTransferedEvent(command.ReceiverAccountId, command.Amount, TransferMoneyStatus.RECEIVE));
        }
    }
}
