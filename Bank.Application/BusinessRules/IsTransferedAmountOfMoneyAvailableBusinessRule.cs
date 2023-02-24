using Bank.Application.AccountDomain.Commands;
using Bank.Core.Entities;

namespace Bank.Application.BusinessRules
{
    public class IsTransferedAmountOfMoneyAvailableBusinessRule : IBusinessRule
    {
        private BankAccounts _bankAccountFrom;
        private MoneyTransferCommand _moneyTransferCommand;

        public string ErrorMessage => "Not sufficient amount of money on account.";

        public IsTransferedAmountOfMoneyAvailableBusinessRule(BankAccounts bankAccountFrom, MoneyTransferCommand command)
        {
            _bankAccountFrom = bankAccountFrom;
            _moneyTransferCommand = command;
        }

        public bool IsValid()
        {
            return _bankAccountFrom.Balance > 0 && _bankAccountFrom.Balance > _moneyTransferCommand.Amount;
        }
    }
}
