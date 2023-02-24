using Bank.Application.CQRS.Interface;
using Bank.Application.Models;
using Bank.Application.Users.Queries;
using Bank.Core.Entities;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.Users.QueryHandlers
{
    public class GetUserDetailsQueryHandler : IHandleQuery<GetUserDetailsQuery, UserDetailsModel>
    {
        private readonly GenericRepository<UserLogins> _loginsRepository;

        public GetUserDetailsQueryHandler(GenericRepository<UserLogins> loginsRepository)
        {
            _loginsRepository = loginsRepository;
        }
        public UserDetailsModel Handle(GetUserDetailsQuery query)
        {
            var user = _loginsRepository.GetById(query.UserId);
            return new UserDetailsModel { Login = user.Login };
        }
    }
}
