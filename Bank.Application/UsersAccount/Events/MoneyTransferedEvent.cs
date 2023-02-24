using Bank.Application.CQRS.Events;
using Bank.Application.Utils.Enums;

namespace Bank.Application.UsersAccount.Events
{
    public class MoneyTransferedEvent : DomainEventBase
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransferMoneyStatus Status { get; set; }

        public MoneyTransferedEvent(int accountId, decimal amount, TransferMoneyStatus status)
        {
            AccountId = accountId;
            Amount = amount;
            Status = status;
        }

    }
}
