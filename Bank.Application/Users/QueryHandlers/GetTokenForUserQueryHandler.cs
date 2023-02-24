using Bank.Application.CQRS.Interface;
using Bank.Application.Users.Queries;
using Bank.Infrastructure.Repositories;
using Bank.Core.Entities;
using Bank.Application.Services;
using Bank.Application.Models;

namespace Bank.Application.Users.QueryHandlers
{
    public class GetTokenForUserQueryHanlder : IHandleQuery<LoginQuery, JWTModel>
    {
        private readonly JWTTokenService _tokenService;
        private readonly GenericRepository<UserLogins> _loginsRepository;

        public GetTokenForUserQueryHanlder(JWTTokenService tokenService, GenericRepository<UserLogins> loginsRepository)
        {
            _tokenService = tokenService;
            _loginsRepository = loginsRepository;
        }
        public JWTModel Handle(LoginQuery query)
        {
            var userAuthDetails = _loginsRepository.GetAll().FirstOrDefault(x => x.Login == query.Login?.ToUpper() && x.Password == query.Password);

            if (userAuthDetails != null)
            {
                return new JWTModel
                {
                    Token = _tokenService.GenerateJWT(query),
                    UserId = userAuthDetails.Id
                };
            }

            return new JWTModel { Token = string.Empty, UserId = -1 };
        }
    }
}
