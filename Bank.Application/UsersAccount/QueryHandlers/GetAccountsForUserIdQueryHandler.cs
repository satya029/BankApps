using Bank.Application.CQRS.Interface;
using Bank.Application.Models;
using Bank.Application.UsersAccount.Queries;
using Bank.Core.Entities;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.UsersAccount.QueryHandlers
{
    public class GetAccountsForUserIdQueryHandler : IHandleQuery<GetAccountForUserIdQuery, IEnumerable<BankAccountModel>>
    {
        private readonly GenericRepository<BankAccounts> _bankAccountRepository;

        public GetAccountsForUserIdQueryHandler(GenericRepository<BankAccounts> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public IEnumerable<BankAccountModel> Handle(GetAccountForUserIdQuery query)
        {
            return _bankAccountRepository.GetAll().GroupBy(a => new { a.Id, a.Balance, a.AccountNo, a.Login }).Where(a => a.Key?.Login?.Id == query.UserId).Select(x => new BankAccountModel
            {
                AccountNo = x.Key.AccountNo,
                Balance = x.Key.Balance??0,
                Id = x.Key.Id
            });
        }
    }
}
