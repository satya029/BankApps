using Bank.Application.CQRS.Interface;
using Bank.Application.UsersAccount.Queries;
using Bank.Core.Entities;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.UsersAccount.QueryHandlers
{
    public class GetAccountQueryByAccountIdHandler : IHandleQuery<GetAccountQueryById, BankAccounts>
    {
        private GenericRepository<BankAccounts> _accounts;

        public GetAccountQueryByAccountIdHandler(GenericRepository<BankAccounts> accounts)
        {
            _accounts = accounts;
        }
        public BankAccounts Handle(GetAccountQueryById query)
        {
            return _accounts.GetById(query.AccountId);
        }
    }
}
